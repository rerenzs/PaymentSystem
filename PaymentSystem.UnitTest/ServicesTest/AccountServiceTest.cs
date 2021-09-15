using NUnit.Framework;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PaymentSystem.Services.Mapping;
using System.Linq;
using PaymentSystem.Domain.IRepositories;
using NSubstitute; 

namespace PaymentSystem.UnitTest.ServicesTest
{
    public class AccountServiceTest
    {

        private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        private readonly IPaymentService paymentService;
        public AccountServiceTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<PaymentSystemProfile>());
            this.mapper = config.CreateMapper();
            accountService = new AccountService(_unitOfWork, mapper, paymentService);

        }
        [Test]
        public void TestGetAccountNumber()  
        {
            

            var accountnumber = accountService.Get(1).AccountNumber;
            Assert.AreEqual(2123123, accountnumber);
        }
        [Test]
        public void TestGetAccountByStatusClose()
        {
            var accountpaymentcount = accountService.Get(1,"closed").Payments.Count();
            Assert.AreEqual(2, accountpaymentcount);
        }

        [Test]
        public void TestGetAccountWithSortedDate()
        {
            var amountwithsortednewestdate = accountService.Get(1).Payments.FirstOrDefault().Amount;
            Assert.AreEqual(1000, amountwithsortednewestdate);
        }

    }
}
