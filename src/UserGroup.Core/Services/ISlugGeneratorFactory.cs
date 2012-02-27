using System;

namespace UserGroup.Services
{
    public interface ISlugGeneratorFactory
    {
        ISlugGenerator<T> GetSlugGenerator<T>();
        ISlugGenerator GetSlugGenerator(Type entityType);
    }
}