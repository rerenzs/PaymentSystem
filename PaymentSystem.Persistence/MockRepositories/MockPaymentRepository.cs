using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PaymentSystem.Persistence.MockRepositories
{
    public class MockPaymentRepository : IPaymentRepository
    {
        public void Add(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Payment Get(long id)
        {
            return this.GetAll().Where(x => x.ID.Equals(id)).FirstOrDefault();
        }

        public IQueryable<Payment> GetAll()
        {
            var payments = new List<Payment>()
            {
                new Payment{ ID = 1, Date = DateTime.Now, Amount = 100, Reason ="reason", Status = "Closed" },
                new Payment{ ID = 2, Date = DateTime.Now, Amount = 200, Reason ="reason2", Status = "Closed" }
            };
            return payments.AsQueryable();
        }

        public IQueryable<Payment> Where(Expression<Func<Payment, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
