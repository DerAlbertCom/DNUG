using System;
using UserGroup.Entities;

namespace UserGroup.Services
{
    public abstract class BaseSlugGenerator<T> : ISlugGenerator<T>
    {
        readonly ISlugger _generator;

        protected BaseSlugGenerator(ISlugger generator)
        {
            this._generator = generator;
        }

        public void Generate(T entity)
        {
            var slug = entity as ISlug;
            if (slug == null)
            {
                throw new ArgumentException("must implement ISlug", "entity");
            }
            slug.SetSlug(_generator.GenerateFrom(GetSlugSource(entity)));
        }

        protected abstract string GetSlugSource(T entity);


        void ISlugGenerator.Generate(object entity)
        {
            Generate((T) entity);
        }
    }
}