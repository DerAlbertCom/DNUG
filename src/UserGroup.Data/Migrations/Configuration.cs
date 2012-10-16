using System.Collections.Generic;
using System.Linq;
using UserGroup.Data;
using UserGroup.Data.Seeders;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace UserGroup.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UserGroupDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UserGroupDbContext context)
        {
            base.Seed(context);
            if (!context.Meetings.Any())
                AddSlugIndex(context, "Meetings");
            if (!context.Speakers.Any())
                AddSlugIndex(context, "Speakers");
            if (!context.Talks.Any())
                AddSlugIndex(context, "Talks");
            if (!context.Locations.Any())
                AddSlugIndex(context, "Locations");
            if (!context.People.Any())
                AddSlugIndex(context, "Pages");
            AddToContext(context, new PeopleSeeder().GetPeople());
            AddToContext(context, new MeetingsSeeder().GetMeetings());
            AddToContext(context, new PageSeeder().GetPages());
        }

        void AddSlugIndex(DbContext context, string tableName)
        {
            string idxName = string.Format(" IDX_{1}_{0}", "Slug", tableName);
            context.Database.ExecuteSqlCommand(string.Format("CREATE UNIQUE INDEX {2} ON {1} ( {0})", "Slug",
                                                             tableName, idxName));
        }

        void AddToContext<T>(DbContext context, IEnumerable<T> source) where T : class
        {
            if (context.Set<T>().Any())
                return;
            foreach (var entity in source)
            {
                context.Set<T>().Add(entity);
            }
        }
    }
}