using Microsoft.EntityFrameworkCore;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Persistence.Interfaces;

namespace PaymentSystem.Persistence.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext ctx) 
            : base(ctx)
        {
        }
    }
}
