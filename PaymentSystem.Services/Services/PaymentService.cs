using AutoMapper;
using AutoMapper.QueryableExtensions;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.IRepositories;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaymentSystem.Domain.Enums;

namespace PaymentSystem.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public PaymentDTO Add(PaymentDTO paymentDTO)
        {
            var payment = this.mapper.Map<PaymentDTO, Payment>(paymentDTO);
            this.unitOfWork.Payment.Add(payment);
            this.unitOfWork.SaveChanges();
            paymentDTO.ID = payment.ID;
            return paymentDTO;
        }

        public PaymentDTO Get(long paymentid)
        {
            return this.GetAll().Where(x => x.ID == paymentid).FirstOrDefault();
        }

        public IQueryable<PaymentDTO> GetAll()
        {
            return from p in unitOfWork.Payment.GetAll()
                   select new PaymentDTO {
                       ID = p.ID,
                       AccountID = p.AccountID,
                       Amount = p.Amount,
                       Date = p.Date,
                       Status = p.Status == Status.Closed.ToString() ? $"{p.Status} - {p.Reason}" : p.Status
                   };
        }

        public IQueryable<PaymentDTO> GetAllByAccountId(long accountid)
        {
            return this.GetAll().Where(x => x.AccountID == accountid).OrderByDescending(x => x.Date);
        }
    }
}
