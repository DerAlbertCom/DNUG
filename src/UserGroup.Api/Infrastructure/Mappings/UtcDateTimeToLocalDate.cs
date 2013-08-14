using System;
using Aperea;
using AutoMapper;

namespace UserGroup.Api.Infrastructure.Mappings
{
    [UsedImplicitly]
    public class UtcDateTimeToLocalDate : ValueResolver<DateTime, DateTime>
    {
        protected override DateTime ResolveCore(DateTime source)
        {
            return source.ToLocalTime().Date;
        }
    }
}