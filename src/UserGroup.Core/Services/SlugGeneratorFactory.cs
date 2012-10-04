using System;
using Microsoft.Practices.ServiceLocation;

namespace UserGroup.Services
{
    public class SlugGeneratorFactory : ISlugGeneratorFactory
    {
        readonly IServiceLocator _locator;

        public SlugGeneratorFactory(IServiceLocator locator)
        {
            _locator = locator;
        }

        public ISlugGenerator<T> GetSlugGenerator<T>()
        {
            return _locator.GetInstance<ISlugGenerator<T>>();
        }

        public ISlugGenerator GetSlugGenerator(Type entityType)
        {
            var slugGenType = typeof (ISlugGenerator<>).MakeGenericType(entityType);
            return (ISlugGenerator) _locator.GetInstance(slugGenType);
        }
    }
}