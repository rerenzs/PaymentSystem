using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace PaymentSystem.Domain.ViewModels
{
    public class PaymentViewModel
    {
        public long ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        [Required]
        public string Status { get; set; }
        public long AccountID { get; set; }
    }
}
