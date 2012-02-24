using System;
using System.Data.Entity;

namespace UserGroup.Data
{
    internal class UserGroupDatabaseDevelopmentInitializer : DropCreateDatabaseIfModelChanges<UserGroupDbContext>
    {
        protected override void Seed(UserGroupDbContext context)
        {
            base.Seed(context);
            var databaseContext = new DatabaseContext(context);

        }
    }
}