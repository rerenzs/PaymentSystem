using System;
using System.Linq;
using System.Linq.Expressions;

namespace PaymentSystem.Persistence.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(long id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        void Add(T entity);
    }
}
