using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Domain.Enums;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IPaymentService paymentService;

        public AccountsController(IAccountService accountService, IPaymentService paymentService)
        {
            this.accountService = accountService;
            this.paymentService = paymentService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var account = new AccountDTO();

                account = accountService.Get(id);
                account.Payments = paymentService.GetAllByAccountId(account.ID);

                if (account != null) return Ok(account);
                else return NotFound();
            }
            catch (Exception ex) {
                return BadRequest($"Failed to get Account:{ex}");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var accounts = accountService.GetAllWithPayments();
                return Ok(accounts); 
            }
            catch (Exception ex) {
                return BadRequest($"Failed to get Accounts:{ex}");
            }
        }
        [HttpPost]
        public IActionResult POST([FromBody]AccountDTO accountDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var account = accountService.Add(accountDTO);
                    return Created($"/api/accounts/{account.ID}", account);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add Account:{ex}");
            }
        }
    }
}
