using DependenctionInjectionMethos.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependenctionInjectionMethos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IDiscount _discount;

        public SalesController(IDiscount discount)
        {
            _discount = discount;
        }


        [HttpGet]

        public IActionResult Get(int amount)
        {
            int discountAmount = _discount.Discount(amount);

            return Ok(new { OriginalAmount = amount, DiscountAmount = discountAmount, FinalAmount = amount - discountAmount });
        }
    }
}
