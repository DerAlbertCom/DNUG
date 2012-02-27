using System;
using UserGroup.Entities;

namespace UserGroup.Services
{
    public class MeetingSlugGenerator : BaseSlugGenerator<Meeting>
    {
        public MeetingSlugGenerator(ISlugger generator) : base(generator)
        {
        }

        protected override string GetSlugSource(Meeting entity)
        {
            return entity.Title;
        }
    }
}