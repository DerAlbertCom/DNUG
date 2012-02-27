using System;
using UserGroup.Entities;

namespace UserGroup.Services
{
    public class TalkSlugGenerator : BaseSlugGenerator<Talk>
    {
        public TalkSlugGenerator(ISlugger generator) : base(generator)
        {
        }

        protected override string GetSlugSource(Talk entity)
        {
            return entity.Title;
        }
    }
}