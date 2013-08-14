using System;
using System.Linq.Expressions;
using AutoMapper;

namespace UserGroup.Infrastructure.Mappings
{
    public static class AutoMapperMappingExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreMember<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapping,
            Expression<Func<TDestination, object>> destinationMember)
        {
            return mapping.ForMember(destinationMember, c => c.Ignore());
        }
    }
}