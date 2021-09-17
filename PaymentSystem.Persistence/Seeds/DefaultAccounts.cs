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
                    Name = "Peter Parker",
                    AccountNumber = 2123123,
                    Balance = 1200,
                    Email = "peter@mail.com",
                    NormalizedEmail = "PETER@MAIL.COM",
                    UserName = "peter@mail.com",
                    NormalizedUserName = "PETER@MAIL.COM",
                },
                new Account
                {
                    Name = "John Doe",
                    AccountNumber = 65456453,
                    Balance = 2000,
                    Email = "john@mail.com",
                    NormalizedEmail = "JOHN@MAIL.COM",
                    UserName = "john@mail.com",
                    NormalizedUserName = "JOHN@MAIL.COM",
                },
            };
        }
    }
}
