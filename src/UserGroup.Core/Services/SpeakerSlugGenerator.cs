using System;
using UserGroup.Entities;

namespace UserGroup.Services
{
    public class SpeakerSlugGenerator : BaseSlugGenerator<Speaker>
    {
        public SpeakerSlugGenerator(ISlugger generator) : base(generator)
        {
        }

        protected override string GetSlugSource(Speaker entity)
        {
            return entity.FullName;
        }
    }
}