using System.Collections.Generic;
using System.Linq;

namespace UserGroup.Commands.Handlers
{

    static internal class CollectionExtensions
    {
        public static void ChangeCollectionTo<T>(this ICollection<T> currentEntities, IEnumerable<T> newEntities)
        {
            var entitiesToRemove = currentEntities.Where(entity => !newEntities.Contains(entity)).ToArray();

            foreach (var entity in entitiesToRemove)
            {
                currentEntities.Remove(entity);
            }

            foreach (var entity in newEntities.Where(speaker => !currentEntities.Contains(speaker)))
            {
                currentEntities.Add(entity);
            }
        }
    } 
}