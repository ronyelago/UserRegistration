using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using UserRegistration.Data;

namespace UserRegistration.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected UserRegistrationContext Db = new UserRegistrationContext();

        public void Add(TEntity obj)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            Db.Set<TEntity>().Add(obj);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate)
        {
            return Db.Set<TEntity>()
                .Where(predicate)
                .ToList();
        }

        public virtual TEntity Get(Func<TEntity, bool> predicate)
        {
            return Db.Set<TEntity>()
                .FirstOrDefault(predicate);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
