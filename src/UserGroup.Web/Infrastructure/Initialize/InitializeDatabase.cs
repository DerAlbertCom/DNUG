using System.Data.Entity;
using Aperea.Infrastructure.Bootstrap;
using UserGroup.Data;

namespace UserGroup.Web.Infrastructure.Initialize
{
    public class InitializeDatabase : BootstrapItem
    {
        public override void Execute()
        {
            Database.SetInitializer(UserGroupDb.GetDatabaseInitializer());
        }
    }
}