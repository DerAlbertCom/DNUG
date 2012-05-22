using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        UserGroupDbContext dbContext;

        public DatabaseContext()
        {
        }

        public DatabaseContext(UserGroupDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DbContext DbContext
        {
            get { return dbContext ?? (dbContext = new UserGroupDbContext()); }
        }

        public void Dispose()
        {
            if (dbContext == null) return;

            dbContext.Dispose();
            dbContext = null;
        }
    }
}