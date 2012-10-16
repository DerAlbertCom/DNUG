using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    public static class UserGroupDb
    {
        public static IDatabaseInitializer<UserGroupDbContext> GetDatabaseInitializer()
        {
            return new UserGroupDatabaseMigrationsInitializer();
        }
    }
}