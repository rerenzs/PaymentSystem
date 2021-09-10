using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PaymentSystem.Domain.IRepositories
{
    public interface IRepository<T> where T : class
    {
        T Get(long id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        void Add(T entity);
    }
}
