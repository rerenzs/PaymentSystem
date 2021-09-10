using PaymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentSystem.Domain.Enums;

namespace PaymentSystem.Persistence.Seeds
{
    public static class DefaultAccounts
    {
        public static List<Account> AccountList() {
            return new List<Account>() {
                new Account
                {
                    ID = 1,
                    Name = "Peter Parker",
                    AccountNumber = 2123123,
                    Balance = 1200,
                },
                new Account
                {
                    ID = 2,
                    Name = "John Doe",
                    AccountNumber = 65456453,
                    Balance = 2000,
                },
            };
        }
    }
}
