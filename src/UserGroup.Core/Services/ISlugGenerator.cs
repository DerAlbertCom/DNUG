using System;

namespace UserGroup.Services
{
    public interface ISlugGenerator
    {
        void Generate(object entity);
    }

    public interface ISlugGenerator<in T>  : ISlugGenerator
    {
        void Generate(T entity);
    }
}