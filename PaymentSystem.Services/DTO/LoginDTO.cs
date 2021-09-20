using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Services.DTO
{
    public class LoginDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string userEmail { get; set; }
        public string password { get; set; }
    }
}