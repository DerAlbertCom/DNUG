using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Aperea;
using Aperea.Data;

namespace UserGroup.Core.Specs
{
    internal class FakeRepository<T> : IRepository<T> where T : class
    {
        readonly List<T> added = new List<T>();
        readonly List<T> entities = new List<T>();
        readonly List<T> removed = new List<T>();

        public FakeRepository(IEnumerable<T> entities)
        {
            AddEntities(entities);
        }

        void AddEntities(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                EntityData.SetEntityId(entity);
                this.entities.Add(entity);
            }
        }

        public IQueryable<T> Entities
        {
            get { return entities.AsQueryable(); }
        }

        public void Add([NotNull] T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            added.Add(entity);
        }

        public void Remove([NotNull] T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            removed.Add(entity);
        }

        public void SaveAllChanges()
        {
            AddEntities(added);
            added.Clear();
            foreach (T removedEntity in removed)
            {
                entities.Remove(removedEntity);
            }
            removed.Clear();
        }

        public IQueryable<T> Include(params string[] paths)
        {
            return Entities;
        }

        public IQueryable<T> Include<TProperty>(params Expression<Func<T, TProperty>>[] expressions)
        {
            return Entities;
        }

        public void Update(T person)
        {
        }

        public void Clear()
        {
            entities.Clear();
            added.Clear();
            removed.Clear();
        }
    }
}