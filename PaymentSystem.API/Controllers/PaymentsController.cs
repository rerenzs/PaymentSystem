using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentSystem.Services.DTO;
using PaymentSystem.Services.Interfaces;
using System.Linq;

namespace PaymentSystem.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IPaymentService paymentService;
        private readonly ILogger<PaymentsController> logger;

        public PaymentsController(IAccountService accountService,
            IPaymentService paymentService,
            ILogger<PaymentsController> logger)
        {
            this.accountService = accountService;
            this.paymentService = paymentService;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation("Fetching account");
            var username = User.Identity.Name;
            var account = accountService.Get(username);
            logger.LogInformation("Fetching account payments");
            account.Payments = paymentService.GetAllByAccountUsername(username);

            if (account != null) return Ok(account);
            else return NotFound("No Records");
        }
        [HttpGet("{paymentid}")]
        public IActionResult Get(long paymentid)
        {
            var username = User.Identity.Name;
            var account = accountService.Get(username);
            if (account != null) { 
                logger.LogInformation("Fetching payment");
                var payment = paymentService.Get(paymentid);
            
                if (payment != null) return Ok(payment);
                else return NotFound("Payment not found");
            }
            return NotFound("Account not found");
        }
    }
}
