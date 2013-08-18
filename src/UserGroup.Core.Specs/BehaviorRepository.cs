using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Aperea.Data;
using Machine.Fakes;
using UserGroup.Entities;

namespace UserGroup.Core.Specs
{
    public class BehaviorRepository<T> where T : class
    {
        static FakeRepository<T> _repository;

        OnEstablish context = accessor =>
        {
            var rep = accessor.The<IRepository<T>>();

            rep.WhenToldTo(r => r.SaveAllChanges()).Callback(() => _repository.SaveAllChanges());
            rep.WhenToldTo(r => r.Add(Param<T>.IsAnything)).Callback<T>(e => _repository.Add(e));
            rep.WhenToldTo(r => r.Remove(Param<T>.IsAnything)).Callback<T>(e => _repository.Remove(e));
            rep.WhenToldTo(r => r.Update(Param<T>.IsAnything)).Callback<T>(e => _repository.Update(e));
            rep.WhenToldTo(r => r.Entities).Return(() => _repository.Entities);
            rep.WhenToldTo(r => r.Include(Param<string[]>.IsAnything)).Return(() => _repository.Entities);
            rep.WhenToldTo(r => r.Include(Param<Expression<Func<T, ICollection<Speaker>>>[]>.IsAnything))
                .Return(() => _repository.Entities);
            rep.WhenToldTo(r => r.Include(Param<Expression<Func<T, ICollection<Talk>>>[]>.IsAnything))
                .Return(() => _repository.Entities);
        };

        OnCleanup subject = subject => _repository.Clear();

        public BehaviorRepository() : this(new T[0])
        {
        }

        public BehaviorRepository(IEnumerable<T> entities)
        {
            _repository = new FakeRepository<T>(entities);
        }
    }
}