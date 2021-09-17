using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Persistence.Interfaces;

namespace PaymentSystem.Persistence.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DbContext ctx) 
            : base(ctx)
        {
        }
    }
}
