using PaymentSystem.Domain.IRepositories;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PaymentSystem.Domain.Entities;
using AutoMapper.QueryableExtensions;

namespace PaymentSystem.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public AccountViewModel Add(AccountViewModel accountViewModel)
        {
            var account = this.mapper.Map<AccountViewModel, Account>(accountViewModel);
            this.unitOfWork.Account.Add(account);
            this.unitOfWork.SaveChanges();
            accountViewModel.ID = account.ID;
            return accountViewModel;

        }

        public AccountViewModel Get(long accountid)
        {
            var account = this.GetAll().Where(x => x.ID == accountid).FirstOrDefault();
            account.Payments = account.Payments.OrderByDescending(x=>x.Date);
            return account;
        }

        public AccountViewModel Get(long accountid, string paymentStatus)
        {
            var account = this.Get(accountid);
            account.Payments = account.Payments.Where(x => string.Equals(x.Status, paymentStatus,StringComparison.CurrentCultureIgnoreCase));
            return account;
        }

        public IQueryable<AccountViewModel> GetAll()
        {
            return this.unitOfWork.Account.GetAll().ProjectTo<AccountViewModel>(mapper.ConfigurationProvider);
        }
    }
}
