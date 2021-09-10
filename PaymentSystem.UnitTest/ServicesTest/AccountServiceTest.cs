using NUnit.Framework;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Persistence.MockRepositories;
using PaymentSystem.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PaymentSystem.Services.Mapping;
using System.Linq;
using PaymentSystem.Domain.IRepositories;

namespace PaymentSystem.UnitTest.ServicesTest
{
    public class AccountServiceTest
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AccountServiceTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<PaymentSystemProfile>());
            this.mapper = config.CreateMapper();

            this.unitOfWork = new MockUnitOfWork();

        }
        [Test]
        public void TestGetAccountNumber()
        {
            IAccountService accountService = new AccountService(this.unitOfWork, this.mapper);

            var accountnumber = accountService.Get(1).AccountNumber;
            Assert.AreEqual(2123123, accountnumber);
        }
        [Test]
        public void TestGetAccountByStatusClose()
        {
            IAccountService accountService = new AccountService(this.unitOfWork, this.mapper);

            var accountpaymentcount = accountService.Get(1,"closed").Payments.Count();
            Assert.AreEqual(2, accountpaymentcount);
        }

        [Test]
        public void TestGetAccountWithSortedDate()
        {
            IAccountService accountService = new AccountService(this.unitOfWork, this.mapper);

            var amountwithsortednewestdate = accountService.Get(1).Payments.FirstOrDefault().Amount;
            Assert.AreEqual(1000, amountwithsortednewestdate);
        }

    }
}
