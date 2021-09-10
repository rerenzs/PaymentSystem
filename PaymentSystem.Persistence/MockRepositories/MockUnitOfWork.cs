using PaymentSystem.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem.Persistence.MockRepositories
{
    public class MockUnitOfWork : IUnitOfWork
    {
        private IPaymentRepository _Payment;
        public IPaymentRepository Payment {
            get 
            {
                if (this._Payment == null)
                    this._Payment = new MockPaymentRepository();
                return this._Payment;
            }
        }

        private IAccountRepository _Account;
        public IAccountRepository Account 
        {
            get
            {
                if (this._Account == null)
                    this._Account = new MockAccountRepository();
                return this._Account;
            }
        }

        public void Dispose()
        {
      
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
