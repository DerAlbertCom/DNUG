using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    internal class UserGroupDatabaseMigrationsInitializer :
        MigrateDatabaseToLatestVersion<UserGroupDbContext, Migrations.Configuration>
    {
        public UserGroupDatabaseMigrationsInitializer()
        {
        }

    }
}