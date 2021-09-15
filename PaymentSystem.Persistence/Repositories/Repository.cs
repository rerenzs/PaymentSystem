using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PaymentSystem.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Add(T entity)
        {
            ctx.Set<T>().Add(entity);
        }

        public T Get(long id)
        {
            return ctx.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return ctx.Set<T>().Where(predicate);
        }
    }
}
