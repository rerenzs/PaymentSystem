using AutoMapper;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem.Services.Mapping
{
    public class PaymentSystemProfile : Profile
    {
        public PaymentSystemProfile()
        {
            this.CreateMap<Account, AccountViewModel>();
            this.CreateMap<Account, AccountViewModel>().ReverseMap();

            this.CreateMap<Payment, PaymentViewModel>();
            this.CreateMap<Payment, PaymentViewModel>().ReverseMap();
        }
    }
}
