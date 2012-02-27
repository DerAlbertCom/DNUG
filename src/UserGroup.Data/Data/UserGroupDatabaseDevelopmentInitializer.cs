using System;
using System.Collections.Generic;
using System.Data.Entity;
using UserGroup.Data.Seeders;
using UserGroup.Entities;

namespace UserGroup.Data
{
    internal class UserGroupDatabaseDevelopmentInitializer : DropCreateDatabaseIfModelChanges<UserGroupDbContext>
    {
        protected override void Seed(UserGroupDbContext context)
        {
            base.Seed(context);
            AddSlugIndex(context, "Meetings");
            AddSlugIndex(context, "Speakers");
            AddSlugIndex(context, "Talks");
            AddSlugIndex(context, "Locations");
            AddSlugIndex(context, "Pages");
            AddToContext(context, new PeopleSeeder().GetPeople());
            AddToContext(context, new MeetingsSeeder().GetMeetings());
            AddToContext(context, new PageSeeder().GetPages());
        }

        void AddSlugIndex(DbContext context, string tableName)
        {
            context.Database.ExecuteSqlCommand(string.Format("CREATE UNIQUE INDEX IDX_{1}_{0} ON {1} ( {0})", "Slug",
                                                             tableName));
        }

        void AddToContext<T>(DbContext context, IEnumerable<T> source) where T : class
        {
            foreach (var entity  in source)
            {
                context.Set<T>().Add(entity);
            }
        }
    }
}