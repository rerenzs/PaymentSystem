using PaymentSystem.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentSystem.Domain.IServices
{
    public interface IPaymentService
    {
        PaymentViewModel Get(long id);
        IQueryable<PaymentViewModel> GetAll();
        PaymentViewModel Add(PaymentViewModel paymentViewModel);
    }
}
