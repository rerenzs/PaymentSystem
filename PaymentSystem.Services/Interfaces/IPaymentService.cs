using PaymentSystem.Services.DTO;
using System.Linq;

namespace PaymentSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        PaymentDTO Get(long id);
        IQueryable<PaymentDTO> GetAll();
        IQueryable<PaymentDTO> GetAllByAccountUsername(string username);
    }
}
