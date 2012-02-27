using System;
using UserGroup.Entities;

namespace UserGroup.Services
{
    public class LocationSlugGenerator : BaseSlugGenerator<Location>
    {
        public LocationSlugGenerator(ISlugger generator)
            : base(generator)
        {
        }

        protected override string GetSlugSource(Location entity)
        {
            return entity.Name;
        }
    }
}