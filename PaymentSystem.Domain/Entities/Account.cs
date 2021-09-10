using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaymentSystem.Domain.Entities
{
    public class Account
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
    }
}
