using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using Aperea.Data;
using Machine.Fakes;
using UserGroup.Entities;

namespace UserGroup.Core.Specs
{
    public class BehaviorRepository<T> where T : class
    {
        static IEnumerable<T> _entities;

        OnEstablish context = accessor =>
        {
            Database.SetInitializer(new UnitTestInitializer());
            accessor.Configure<IDatabaseContext>(new UnitTestDatabaseContext(new UnitTestDbContext()));
            var repository = new Repository<T>(accessor.The<IDatabaseContext>());
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

            var rep = accessor.The<IRepository<T>>();
            rep.WhenToldTo(r => r.SaveAllChanges()).Callback(repository.SaveAllChanges);
            rep.WhenToldTo(r => r.Add(Param.IsAny<T>())).Callback<T>(repository.Add);
            rep.WhenToldTo(r => r.Remove(Param.IsAny<T>())).Callback<T>(repository.Remove);
            rep.WhenToldTo(r => r.Update(Param.IsAny<T>())).Callback<T>(repository.Update);
            rep.WhenToldTo(r => r.Entities).Return(() => repository.Entities);
            rep.WhenToldTo(r => r.Include(Param.IsAny<string[]>())).Return<string[]>(repository.Include);
            rep.WhenToldTo(r => r.Include(Param.IsAny<Expression<Func<T, Speaker>>[]>()))
                .Return<Expression<Func<T, Speaker>>[]>(repository.Include);
            rep.WhenToldTo(r => r.Include(Param.IsAny<Expression<Func<T, Talk>>[]>()))
                .Return<Expression<Func<T, Talk>>[]>(repository.Include);
            rep.WhenToldTo(r => r.Include(Param.IsAny<Expression<Func<T, Meeting>>[]>()))
                .Return<Expression<Func<T, Meeting>>[]>(repository.Include);
            rep.WhenToldTo(r => r.Include(Param.IsAny<Expression<Func<T, Location>>[]>()))
                .Return<Expression<Func<T, Location>>[]>(repository.Include);

            rep.WhenToldTo(r => r.Include(Param.IsAny<Expression<Func<T, ICollection<Speaker>>>[]>()))
                .Return<Expression<Func<T,ICollection<Speaker>>>[]>(repository.Include);
            rep.WhenToldTo(r => r.Include(Param.IsAny<Expression<Func<T, ICollection<Talk>>>[]>()))
                .Return<Expression<Func<T, ICollection<Talk>>>[]>(repository.Include);
            rep.WhenToldTo(r => r.Include(Param.IsAny<Expression<Func<T, ICollection<Meeting>>>[]>()))
                .Return<Expression<Func<T, ICollection<Meeting>>>[]>(repository.Include);
            rep.WhenToldTo(r => r.Include(Param.IsAny<Expression<Func<T, ICollection<Location>>>[]>()))
                .Return<Expression<Func<T, ICollection<Location>>>[]>(repository.Include);

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