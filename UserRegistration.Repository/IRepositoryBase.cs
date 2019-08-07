using System;
using System.Collections.Generic;

namespace UserRegistration.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate);
        TEntity Get(Func<TEntity, bool> predicate);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
