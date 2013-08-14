using System;
using Aperea;
using AutoMapper;

namespace UserGroup.Api.Infrastructure.Mappings
{
    [UsedImplicitly]
    public class UtcDateTimeToLocalTimeSpan : ValueResolver<DateTime, TimeSpan>
    {
        protected override TimeSpan ResolveCore(DateTime source)
        {
            return source.ToLocalTime().TimeOfDay;
        }
    }
}