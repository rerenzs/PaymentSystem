using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem.Persistence.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(PaymentSystemContext ctx) 
            : base(ctx)
        {
        }
    }
}
