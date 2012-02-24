﻿using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace UserGroup.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        readonly IDatabaseContext context;

        readonly Lazy<DbSet<T>> database;

        public Repository(IDatabaseContext context)
        {
            this.context = context;
            database = new Lazy<DbSet<T>>(() => context.DbContext.Set<T>(), isThreadSafe: false);
        }

        public IQueryable<T> Entities
        {
            get { return database.Value; }
        }

        public void Add(T entity)
        {
            database.Value.Add(entity);
        }

        public void Remove(T entity)
        {
            database.Value.Remove(entity);
        }

        public IQueryable<T> Include<TProperty>(params Expression<Func<T, TProperty>>[] expressions)
        {
            DbQuery<T> query = database.Value;
            foreach (var expression in expressions)
            {
                return database.Value.Include(expression);
            }
            return query;
        }


        public void Update(T person)
        {
            context.DbContext.Entry(person).State = EntityState.Modified;
        }

        public IQueryable<T> Include(params string[] paths)
        {
            DbQuery<T> query = database.Value;
            foreach (var path in paths)
            {
                query = query.Include(path);
            }
            return query;
        }

        public void SaveChanges()
        {
            context.DbContext.SaveChanges();
        }
    }
}