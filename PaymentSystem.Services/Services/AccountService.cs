using PaymentSystem.Domain.IRepositories;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PaymentSystem.Domain.Entities;
using AutoMapper.QueryableExtensions;
using PaymentSystem.Domain.Enums;

namespace PaymentSystem.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPaymentService paymentService;

        public AccountService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IPaymentService paymentService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.paymentService = paymentService;
        }
        public AccountDTO Add(AccountDTO accountDTO)
        {
            var account = this.mapper.Map<AccountDTO, Account>(accountDTO);
            this.unitOfWork.Account.Add(account);
            this.unitOfWork.SaveChanges();
            accountDTO.ID = account.ID;
            return accountDTO;

        }

        public AccountDTO Get(long accountid)
        {
            var account = this.GetAll().Where(x => x.ID == accountid).SingleOrDefault();
            return account;
        }

        public AccountDTO Get(long accountid, string paymentStatus)
        {
            var account = this.Get(accountid);
            account.Payments = account.Payments.Where(x => string.Equals(x.Status, paymentStatus,StringComparison.CurrentCultureIgnoreCase));
            return account;
        }

        public IQueryable<AccountDTO> GetAll()
        {
            return from u in unitOfWork.Account.GetAll()
                   select new AccountDTO
                   {
                       ID = u.ID,
                       AccountNumber = u.AccountNumber,
                       Balance = u.Balance,
                       Name = u.Name
                   };
        }

        public IEnumerable<AccountDTO> GetAllWithPayments()
        {
            var accounts = this.GetAll().ToList();
            foreach (AccountDTO account in accounts) {
                account.Payments = paymentService.GetAllByAccountId(account.ID).ToList();
            }
            return accounts;
        }

    }
}
