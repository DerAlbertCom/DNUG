using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        Lazy<DbContext> dbContext;

        public DatabaseContext(IDbContextFactory cbContextfactory)
        {
            dbContext = new Lazy<DbContext>(cbContextfactory.Create);
        }

        public DbContext DbContext
        {
            get { return dbContext.Value; }
        }

        public void Dispose()
        {
            if (dbContext == null || !dbContext.IsValueCreated) return;

            if (dbContext.IsValueCreated)
            {
                dbContext.Value.Dispose();
            }
            dbContext = null;
        }
    }
}