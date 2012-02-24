using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    public class CreateDatabaseIfNotExistsWithoutModelCheck<TContext> : IDatabaseInitializer<TContext>
        where TContext : DbContext
    {
// ReSharper disable StaticFieldInGenericType
        static readonly object LockObject = new object();
        static bool initialized = false;
        // ReSharper restore StaticFieldInGenericType

        public void InitializeDatabase(TContext context)
        {
            if (!initialized)
            {
                lock (LockObject)
                {
                    if (!initialized)
                    {
                        if (!context.Database.Exists())
                        {
                            context.Database.Create();
                            Seed(context);
                            context.SaveChanges();
                            context.Dispose();
                        }
                        initialized = true;
                    }
                }
            }
        }
        protected virtual void Seed(TContext context)
        {
        }
    }
}