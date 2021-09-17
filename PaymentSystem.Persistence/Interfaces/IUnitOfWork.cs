using System;

namespace PaymentSystem.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentRepository Payment { get; }
        IAccountRepository Account { get; }
        bool SaveChanges();
    }
}
