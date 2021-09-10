using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Domain.Enums;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Domain.ViewModels;
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

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id, string status)
        {
            try
            {
                var account = new AccountViewModel();

                if (status!=null){
                    account = accountService.Get(id,status); 
                }
                else {
                    account = accountService.Get(id);
                }

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
                var account = accountService.GetAll();
                return Ok(account); 
            }
            catch (Exception ex) {
                return BadRequest($"Failed to get Accounts:{ex}");
            }
        }
        [HttpPost]
        public IActionResult POST([FromBody]AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var account = accountService.Add(accountViewModel);
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
