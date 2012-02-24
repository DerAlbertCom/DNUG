using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    public static class UserGroupDb
    {
        public static IDatabaseInitializer<UserGroupDbContext> GetDevelopmentInitializer()
        {
            return new UserGroupDatabaseDevelopmentInitializer();
        }
    }
}