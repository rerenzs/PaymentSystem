using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.Enums;
using PaymentSystem.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PaymentSystem.Persistence.MockRepositories
{
    public class MockAccountRepository : IAccountRepository
    {
        public void Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public Account Get(long id)
        {
            return this.GetAll().Where(x => x.ID.Equals(id)).FirstOrDefault(); 
        }

        public IQueryable<Account> GetAll()
        {
            var accounts = new List<Account>()
            {      
                new Account
                {
                    ID = 1,
                    Name = "Peter Parker",
                    AccountNumber = 2123123,
                    Balance = 1200,
                    Payments = new List<Payment>() {
                        new Payment
                        {
                            ID = 1,
                            AccountID = 1,
                            Amount = 1000,
                            Status = Status.Closed.ToString(),
                            Date = DateTime.Now,
                            Reason = "some reason",

                        },
                        new Payment
                        {
                            ID = 2,
                            AccountID = 1,
                            Amount = 5000,
                            Status = Status.Pending.ToString(),
                            Date = DateTime.Now.AddDays(-1),
                            Reason = "",

                        },
                        new Payment
                        {
                            ID = 3,
                            AccountID = 1,
                            Amount = 1000,
                            Status = Status.Closed.ToString(),
                            Date = DateTime.Now.AddDays(-2),
                            Reason = "some reason",

                        },
                    }
                },
                new Account
                {
                    ID = 2,
                    Name = "John Doe",
                    AccountNumber = 65456453,
                    Balance = 2000,
                    Payments = new List<Payment>() { 
                        new Payment
                        {
                            ID = 3,
                            AccountID = 2,
                            Amount = 500,
                            Status = Status.Closed.ToString(),
                            Date = DateTime.Now,
                            Reason = "some reason",

                        } 
                    }
                },
                  
            };
            return accounts.AsQueryable();
        }

        public IQueryable<Account> Where(Expression<Func<Account, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
