using AutoMapper;
using AutoMapper.QueryableExtensions;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.IRepositories;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentSystem.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IAccountService accountService;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.accountService = accountService;
        }
        public PaymentViewModel Add(PaymentViewModel paymentViewModel)
        {
            var payment = this.mapper.Map<PaymentViewModel, Payment>(paymentViewModel);
            this.unitOfWork.Payment.Add(payment);
            this.unitOfWork.SaveChanges();
            paymentViewModel.ID = payment.ID;
            return paymentViewModel;
        }

        public PaymentViewModel Get(long paymentid)
        {
            return this.GetAll().Where(x => x.ID == paymentid).FirstOrDefault();
        }

        public IQueryable<PaymentViewModel> GetAll()
        {
            return this.unitOfWork.Payment.GetAll().ProjectTo<PaymentViewModel>(mapper.ConfigurationProvider);
        }
    }
}
