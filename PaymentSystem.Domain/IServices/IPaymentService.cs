using PaymentSystem.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentSystem.Domain.IServices
{
    public interface IPaymentService
    {
        PaymentDTO Get(long id);
        IQueryable<PaymentDTO> GetAll();
        IQueryable<PaymentDTO> GetAllByAccountId(long accountid);
        PaymentDTO Add(PaymentDTO paymentDTO);
    }
}
