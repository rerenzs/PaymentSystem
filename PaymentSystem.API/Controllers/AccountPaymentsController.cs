using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.API.Controllers
{
    [ApiController]
    [Route("api/accounts/{accountid}/payments")]
    public class AccountPaymentsController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IPaymentService paymentService;

        public AccountPaymentsController(IAccountService accountService, IPaymentService paymentService)
        {
            this.accountService = accountService;
            this.paymentService = paymentService;
        }
        [HttpGet]
        public IActionResult Get(long accountid)
        {
            try
            {
                var account = accountService.Get(accountid);
                account.Payments = paymentService.GetAllByAccountId(account.ID);

                if (account != null) return Ok(account.Payments);          
                else return NotFound("Account not Found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Payments:{ex}");
            }
        }
        [HttpGet("{paymentid}")]
        public IActionResult Get(long accountid,long paymentid)

        {
            try
            {
                var account = accountService.Get(accountid);
                account.Payments = paymentService.GetAllByAccountId(account.ID);

                if (account != null) {
                    var payment = account.Payments.Where(x => x.ID == paymentid).FirstOrDefault();

                    if (payment != null) return Ok(payment);
                    else return NotFound("Payment not found");
                }
                else return NotFound("Account not Found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Payment:{ex}");
            }
        }
        [HttpPost]
        public IActionResult POST(long accountid,[FromBody] PaymentDTO paymentDTO)
        {
            try
            {
                var account = accountService.Get(accountid);
                if (account != null)
                {
                    paymentDTO.AccountID = accountid;
                    if (ModelState.IsValid)
                    {
                        var payment = paymentService.Add(paymentDTO);
                        return Created($"/api/accounts/{accountid}/payments/{payment.ID}", payment);
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                else 
                {
                    return NotFound($"Account {accountid} Not Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add Payment:{ex}");
            }
        }

    }
}
