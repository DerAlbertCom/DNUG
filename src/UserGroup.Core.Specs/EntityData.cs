using System.Collections.Generic;
using System.Reflection;

namespace UserGroup.Core.Specs
{
    internal static class EntityData
    {
        static int _idCount = 0;

        public static void SetEntityId<T>(T entity) where T : class
        {
            _idCount++;
            var property = entity.GetType()
                .GetProperty("Id", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if ((int) property.GetValue(entity, null) == 0)
            {
                property.SetValue(entity, _idCount, null);
            }
        }

        public static void SetEntityIds<T>(IEnumerable<T>  entities) where T : class
        {
            foreach (var entity in entities)
            {
                SetEntityId(entity);
            }
        }
    }
}