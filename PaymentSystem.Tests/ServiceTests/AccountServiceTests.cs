using NSubstitute;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.Enums;
using PaymentSystem.Persistence.Interfaces;
using PaymentSystem.Services.Interfaces;
using PaymentSystem.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PaymentSystem.Tests.ServiceTests
{
    public class AccountServiceTests
    {

        private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
        private readonly IAccountService accountService;
        private readonly IPaymentService paymentService;

        public AccountServiceTests()
        {

            paymentService = new PaymentService(_unitOfWork);
            accountService = new AccountService(_unitOfWork, paymentService);
            var peteraccount = new Account
            {
                Name = "Peter Parker",
                AccountNumber = 2123123,
                Balance = 1200,
                UserName = "peter@mail.com",
                Id = "985a4de8-ff19-4c44-b3dd-1b3d6894a5e1"
            };
            var accounts = new List<Account>(){ peteraccount };
            var payments = new List<Payment>() {
                            new Payment
                            {
                                ID = 1,
                                Amount = 1000,
                                Status = Status.Closed.ToString(),
                                Date = DateTime.Now.AddDays(-3),
                                Reason = "Resolved",
                                Account = peteraccount

                            },
                            new Payment
                            {
                                ID = 2,
                                Amount = 5000,
                                Status = Status.Pending.ToString(),
                                Date = DateTime.Now,
                                Reason = "test",
                                Account = peteraccount

                            },
                            new Payment
                            {
                                ID = 3,
                                Amount = 1000,
                                Status = Status.Closed.ToString(),
                                Date = DateTime.Now.AddDays(-2),
                                Reason = "Duplicate",
                                Account = peteraccount
                            },
                        };

            _unitOfWork.Account.GetAll().Returns(accounts.AsQueryable());
            _unitOfWork.Payment.GetAll().Returns(payments.AsQueryable());

        }
        [Fact]
        public void TestGetAccountStatus()
        {
            var account = accountService.Get("peter@mail.com");
            account.Payments = paymentService.GetAllByAccountUsername(account.username);

            var paymentWithClosedStatus = account.Payments.Where(x => x.ID == 3).FirstOrDefault();
            var paymentWithPendingStatus = account.Payments.Where(x => x.ID == 2).FirstOrDefault();

            Assert.Equal("Closed - Duplicate", paymentWithClosedStatus.Status);
            Assert.Equal("Pending", paymentWithPendingStatus.Status);
        }
        [Fact]
        public void TestGetAccountPaymentLatestDate()
        {

            var account = accountService.Get("peter@mail.com");
            account.Payments = paymentService.GetAllByAccountUsername(account.username);

            var paymentWithLatestDate = account.Payments.FirstOrDefault();

            Assert.Equal(2, paymentWithLatestDate.ID);
        }

    }
}
