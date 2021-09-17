using PaymentSystem.Persistence.Interfaces;
using PaymentSystem.Services.DTO;
using PaymentSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PaymentSystem.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPaymentService paymentService;

        public AccountService(IUnitOfWork unitOfWork,
            IPaymentService paymentService)
        {
            this.unitOfWork = unitOfWork;
            this.paymentService = paymentService;
        }

        public AccountDTO Get(string username)
        {
            return  this.GetAll().Where(x => x.username == username).SingleOrDefault();
        }

        public IQueryable<AccountDTO> GetAll()
        {
            return from u in unitOfWork.Account.GetAll()
                   select new AccountDTO
                   {
                       AccountNumber = u.AccountNumber,
                       Balance = u.Balance,
                       Name = u.Name,
                       username = u.UserName,
                   };
        }

        public IEnumerable<AccountDTO> GetAllWithPayments()
        {
            var accounts = this.GetAll().ToList();
            foreach (AccountDTO account in accounts) {
                account.Payments = paymentService.GetAllByAccountUsername(account.username).ToList();
            }
            return accounts;
        }

    }
}
