using System;
using System.Linq;
using System.Linq.Expressions;
using Aperea.Data;
using Machine.Fakes;
using UserGroup.Entities;

namespace UserGroup.Core.Specs.Commands
{
    public static class UpdateEntitiesExtensions
    {
        public static void UpdateEnties<T,TProperty>(this IFakeAccessor accessor, T[] entities, Expression<Func<T, TProperty>> includeExpression) where T : class, IHasId
        {
            for (int i = 0; i < entities.Length; i++)
            {
                var id = entities[i].Id;
                entities[i] = accessor.The<IRepository<T>>().Include(includeExpression).SingleOrDefault(e => e.Id == id);
            }
        }

        public static void UpdateEnties<T>(this IFakeAccessor accessor, T[] entities) where T : class, IHasId
        {
            for (int i = 0; i < entities.Length; i++)
            {
                var id = entities[i].Id;
                entities[i] = accessor.The<IRepository<T>>().Entities.SingleOrDefault(e => e.Id == id);
            }
        }
    }
}