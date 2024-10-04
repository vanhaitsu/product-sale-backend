using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models.CartModels;

namespace API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost()]
        //[Authorize(Roles = "User, Expert")]
        public async Task<IActionResult> Create([FromBody] CartItemCreateModel cartItemCreateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }
                var result = await _cartItemService.Create(cartItemCreateModel);
                if (result.Status)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
