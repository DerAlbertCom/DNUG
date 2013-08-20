using System.Data.Entity;
using Aperea.Data;
using Machine.Specifications;

namespace UserGroup.Core.Specs
{
    public class UnitTestDatabaseContext : IDatabaseContext, ICleanupAfterEveryContextInAssembly, IAssemblyContext
    {
        static DbContext _dbContext;

        public UnitTestDatabaseContext()
        {
        }

        public UnitTestDatabaseContext(DbContext dbContext)
        {
            if (_dbContext == null)
            {
                _dbContext = dbContext;
            }
            else
            {
                dbContext.Dispose();
            }
        }

        public void Dispose()
        {
            AfterContextCleanup();
        }

        public DbContext DbContext
        {
            get { return _dbContext; }
        }

        public void AfterContextCleanup()
        {
            if (_dbContext == null) return;
            DeleteTables(_dbContext);
            _dbContext.Dispose();
            _dbContext = null;
        }

        void DeleteTables(DbContext dbContext)
        {
            //_dbContext.Database.ExecuteSqlCommand("delete from Speakers");
            //_dbContext.Database.ExecuteSqlCommand("delete from Talks");
        }

        public void OnAssemblyStart()
        {
            Database.SetInitializer(new UnitTestInitializer());
        }

        public void OnAssemblyComplete()
        {
        }
    }
}