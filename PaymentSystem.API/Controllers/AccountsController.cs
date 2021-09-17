using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Services.Interfaces;

namespace PaymentSystem.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var accounts = accountService.GetAllWithPayments();
            return Ok(accounts);
        }

    }
}
