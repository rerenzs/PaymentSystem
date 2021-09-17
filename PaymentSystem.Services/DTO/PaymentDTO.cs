using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Services.DTO
{
    public class PaymentDTO
    {
        public long ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        [Required]
        public string Status { get; set; }
        public string AccountUsername { get; set; }
    }
}
