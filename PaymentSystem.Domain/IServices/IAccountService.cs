using PaymentSystem.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentSystem.Domain.IServices
{
    public interface IAccountService
    {
        AccountViewModel Get(long id);
        AccountViewModel Get(long id,string paymentStatus);
        IQueryable<AccountViewModel> GetAll();
        AccountViewModel Add(AccountViewModel accountViewModel);
    }
}
