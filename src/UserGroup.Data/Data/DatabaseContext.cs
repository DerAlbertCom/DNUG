using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        Lazy<DbContext> _dbContext;

        public DatabaseContext(IDbContextFactory cbContextfactory)
        {
            _dbContext = new Lazy<DbContext>(cbContextfactory.Create);
        }

        public DbContext DbContext
        {
            get { return _dbContext.Value; }
        }

        public void Dispose()
        {
            if (_dbContext == null || !_dbContext.IsValueCreated) return;

            if (_dbContext.IsValueCreated)
            {
                _dbContext.Value.Dispose();
            }
            _dbContext = null;
        }
    }
}