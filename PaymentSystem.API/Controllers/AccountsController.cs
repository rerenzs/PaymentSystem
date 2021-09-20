using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentSystem.Services.Interfaces;

namespace PaymentSystem.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly ILogger<AccountsController> logger;

        public AccountsController(IAccountService accountService,
            ILogger<AccountsController> logger)
        {
            this.accountService = accountService;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation("Fetching all accounts with payments");
            var accounts = accountService.GetAllWithPayments();
            return Ok(accounts); 
        }

    }
}
