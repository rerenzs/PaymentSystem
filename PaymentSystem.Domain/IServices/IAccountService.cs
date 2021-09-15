using PaymentSystem.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentSystem.Domain.IServices
{
    public interface IAccountService
    {
        AccountDTO Get(long id);
        AccountDTO Get(long id,string paymentStatus);
        IQueryable<AccountDTO> GetAll();
        IEnumerable<AccountDTO> GetAllWithPayments();
        AccountDTO Add(AccountDTO accountDTO);
    }
}
