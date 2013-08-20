using System.Collections.Generic;
using System.Data.Entity;
using Aperea.Data;
using Machine.Fakes;
using UserGroup.Data;
using UserGroup.Entities;

namespace UserGroup.Core.Specs
{
    public class BehaviorRepository<T> where T : class
    {
        static IEnumerable<T> _entities;

        OnEstablish context = accessor =>
        {
            accessor.Configure<IDatabaseContext>(new UnitTestDatabaseContext(new UserGroupDbContext()));
            var repository = new Repository<T>(accessor.The<IDatabaseContext>());
            accessor.Configure<IRepository<T>>(repository);

            foreach (var entity in _entities)
            {
                var hasId = entity as IHasId;
                if (hasId == null)
                {
                    repository.Add(entity);
                }
                else
                {
                    if (hasId.Id == 0)
                    {
                        repository.Add(entity);
                    }
                }
            }
            repository.SaveAllChanges();
        };

        public BehaviorRepository()
            : this(new T[0])
        {
        }

        public BehaviorRepository(params T[] entities)
            : this((IEnumerable<T>) entities)
        {
        }

        public BehaviorRepository(IEnumerable<T> entities)
        {
            _entities = entities;
        }
    }
}