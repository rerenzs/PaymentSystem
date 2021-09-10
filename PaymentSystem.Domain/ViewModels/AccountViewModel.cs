using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentSystem.Domain.ViewModels
{
    public class AccountViewModel
    {
        public long ID { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }
        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
