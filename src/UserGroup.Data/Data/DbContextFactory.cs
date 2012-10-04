using System;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using UserGroup.Services;

namespace UserGroup.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        readonly IServiceLocator _locator;

        public DbContextFactory(IServiceLocator locator)
        {
            _locator = locator;
        }

        public DbContext Create()
        {
            return new UserGroupDbContext(_locator.GetInstance<ISlugGeneratorFactory>());
        }
    }
}