using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaymentSystem.Domain.Entities
{
    public class Payment
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public long AccountID { get; set; }
        public Account Account { get; set; }
    }
}
