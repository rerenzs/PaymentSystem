using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem.Persistence.Seeds
{
    public static class DefaultPayments
    {
        public static List<Payment> PaymentList()
        {
            return new List<Payment>() {
                new Payment
                {
                    ID = 1,
                    AccountID = 1,
                    Amount = 1000,
                    Status = Status.Closed.ToString(),
                    Date = DateTime.Now,
                    Reason = "Duplicate",

                },
                new Payment
                {
                    ID = 2,
                    AccountID = 1,
                    Amount = 5000,
                    Status = Status.Closed.ToString(),
                    Date = DateTime.Now,
                    Reason = "resolved",

                },
                new Payment
                {
                    ID = 3,
                    AccountID = 2,
                    Amount = 500,
                    Status = Status.Pending.ToString(),
                    Date = DateTime.Now,
                    Reason = "some reason",

                },
            };
        }
    }
}
