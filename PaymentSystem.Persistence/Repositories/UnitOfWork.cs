using PaymentSystem.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private PaymentSystemContext _ctx = null;
        private PaymentSystemContext _context
        {
            get
            {
                if (_ctx == null)
                {
                    _ctx = new PaymentSystemContext();
                }
                return _ctx;
            }
        }
        private IPaymentRepository _Payment;
        public IPaymentRepository Payment
        {
            get
            {
                if (this._Payment == null)
                    this._Payment = new PaymentRepository(this._context);
                return this._Payment;
            }
        }
        private IAccountRepository _Account;
        public IAccountRepository Account
        {
            get
            {
                if (this._Account == null)
                    this._Account = new AccountRepository(this._context);
                return this._Account;
            }
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
