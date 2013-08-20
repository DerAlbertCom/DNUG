using System.Data.Entity;
using UserGroup.Data;

namespace UserGroup.Core.Specs
{
    public class UnitTestDbContext : UserGroupDbContext
    {
        public UnitTestDbContext():base("Data Source=UserGroupUnitTestDb.sdf;Persist Security Info=False;")
        {
            
        }
    }

    public class UnitTestInitializer : DropCreateDatabaseIfModelChanges<UnitTestDbContext>
    {
        
    }
}