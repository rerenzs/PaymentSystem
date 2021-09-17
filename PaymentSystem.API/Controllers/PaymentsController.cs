using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public PaymentsController(IAccountService accountService,
            IPaymentService paymentService)
        {
            this.accountService = accountService;
            this.paymentService = paymentService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var username = User.Identity.Name;
            var account = accountService.Get(username);
            account.Payments = paymentService.GetAllByAccountUsername(username);

            if (account != null) return Ok(account);
            else return NotFound("No Records");
        }
        [HttpGet("{paymentid}")]
        public IActionResult Get(long paymentid)
        {
            var username = User.Identity.Name;
            var account = accountService.Get(username);
            account.Payments = paymentService.GetAllByAccountUsername(username);

            var payment = account.Payments.Where(x => x.ID == paymentid).SingleOrDefault();
            
            if (payment != null) return Ok(payment);
            else return NotFound("Payment not found");

        }
    }
}
