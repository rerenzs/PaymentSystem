using AutoMapper;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentSystem.Domain.Enums;
using System.Linq;

namespace PaymentSystem.Services.Mapping
{
    public class PaymentSystemProfile : Profile
    {
        public PaymentSystemProfile()
        {

            this.CreateMap<PaymentDTO, Payment>();
            this.CreateMap<PaymentDTO, Payment > ().ReverseMap();

            this.CreateMap<Account, AccountDTO>();
            this.CreateMap<Account, AccountDTO>().ReverseMap();


        }
    }
}
