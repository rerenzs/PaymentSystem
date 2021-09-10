using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem.Domain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentRepository Payment { get; }
        IAccountRepository Account { get; }
        bool SaveChanges();
    }
}
