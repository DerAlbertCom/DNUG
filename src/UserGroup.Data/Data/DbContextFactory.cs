using System;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using UserGroup.Services;

namespace UserGroup.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        readonly IServiceLocator locator;

        public DbContextFactory(IServiceLocator locator)
        {
            this.locator = locator;
        }

        public DbContext Create()
        {
            return new UserGroupDbContext(locator.GetInstance<ISlugGeneratorFactory>());
        }
    }
}