using System;
using Microsoft.Practices.ServiceLocation;

namespace UserGroup.Services
{
    public class SlugGeneratorFactory : ISlugGeneratorFactory
    {
        readonly IServiceLocator locator;

        public SlugGeneratorFactory(IServiceLocator locator)
        {
            this.locator = locator;
        }

        public SlugGeneratorFactory() : this(ServiceLocator.Current)
        {
        }

        public ISlugGenerator<T> GetSlugGenerator<T>()
        {
            return locator.GetInstance<ISlugGenerator<T>>();
        }

        public ISlugGenerator GetSlugGenerator(Type entityType)
        {
            var slugGenType= typeof (ISlugGenerator<>).MakeGenericType(entityType);
            return (ISlugGenerator) locator.GetInstance(slugGenType);
        }
    }
}