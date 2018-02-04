using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATS.Models.Interfaces.Repository
{
    public interface ICommonRepository<T> : IDisposable where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        ICollection<T> Get(Expression<Func<T, bool>> query);
    }
}
