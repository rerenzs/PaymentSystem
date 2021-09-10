using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var payment = paymentService.Get(id);

                if (payment != null) return Ok(payment);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Payment:{ex}");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var account = paymentService.GetAll();
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Payments:{ex}");
            }
        }
    }
}
