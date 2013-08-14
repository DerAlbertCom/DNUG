using System;
using Aperea;
using AutoMapper;

namespace UserGroup.Api.Infrastructure.Mappings
{
    [UsedImplicitly]
    public class LocalDateTimeToUtcDateTime : ValueResolver<DateTime, DateTime>
    {
        protected override DateTime ResolveCore(DateTime source)
        {
            return source.ToUniversalTime();
        }
    }
}