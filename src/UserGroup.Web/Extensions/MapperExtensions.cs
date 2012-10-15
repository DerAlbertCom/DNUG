using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace UserGroup.Web.Extensions
{
    public static class MapperExtensions
    {
        public static IEnumerable<TResult> ToList<TResult>(this IQueryable source)
        {
            return Mapper.Map<IEnumerable<TResult>>(source);
        }

        public static void MapTo<TDestination>(this object value, TDestination destination)
        {
            Mapper.Map(value, destination, value.GetType(), typeof (TDestination));
        }
    }
}