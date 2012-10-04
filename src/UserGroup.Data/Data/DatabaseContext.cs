using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        readonly IDbContextFactory _factory;
        Lazy<DbContext> _dbContext;

        public DatabaseContext(IDbContextFactory factory)
        {
            _factory = factory;
            _dbContext = new Lazy<DbContext>(CreateDbContext);
        }

        DbContext CreateDbContext()
        {
            return _factory.Create();
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