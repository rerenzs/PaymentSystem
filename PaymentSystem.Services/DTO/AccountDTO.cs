using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Services.DTO
{
    public class AccountDTO
    {
        public int AccountNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }
        public string username { get; set; }
        public IEnumerable<PaymentDTO> Payments { get; set; }
    }
}
