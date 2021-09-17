using PaymentSystem.Services.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PaymentSystem.Services.Interfaces
{
    public interface IAccountService
    {
        AccountDTO Get(string username);
        IQueryable<AccountDTO> GetAll();
        IEnumerable<AccountDTO> GetAllWithPayments();
    }
}
