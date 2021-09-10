using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem.Persistence.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentSystemContext ctx) 
            : base(ctx)
        {
        }
    }
}
