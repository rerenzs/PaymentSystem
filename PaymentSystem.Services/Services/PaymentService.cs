using PaymentSystem.Domain.Enums;
using PaymentSystem.Persistence.Interfaces;
using PaymentSystem.Services.DTO;
using PaymentSystem.Services.Interfaces;
using System.Linq;

namespace PaymentSystem.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PaymentDTO Get(long paymentid)
        {
            return this.GetAll().Where(x => x.ID == paymentid).FirstOrDefault();
        }

        public IQueryable<PaymentDTO> GetAll()
        {
            return from p in unitOfWork.Payment.GetAll()
                   select new PaymentDTO {
                       ID = p.ID,
                       Amount = p.Amount,
                       AccountUsername = p.Account.UserName,
                       Date = p.Date,
                       Status = p.Status == Status.Closed.ToString() ? $"{p.Status} - {p.Reason}" : p.Status
                   };
        }

        public IQueryable<PaymentDTO> GetAllByAccountUsername(string username)
        {
            return this.GetAll().Where(x => x.AccountUsername == username).OrderByDescending(x => x.Date);
        }
    }
}
