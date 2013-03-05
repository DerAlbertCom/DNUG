using System;
using System.Data.Entity;
using Aperea.Data;
using Aperea.Infrastructure.Bootstrap;
using UserGroup.Data;

namespace UserGroup.Web.Infrastructure.Initialize
{
    public class InitializeDatabase : BootstrapItem
    {
        public override void Execute()
        {
            DbContextFactory.SetDbContextType<UserGroupDbContext>();
            Database.SetInitializer(UserGroupDb.GetDatabaseInitializer());
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
        }
    }
}