using Azure.Core;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories.Entities;
using Services.Interfaces;
using Services.Models.CartItemModels;
using Services.Models.CartModels;
using Services.Models.ProductModels;
using Services.Services;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace API.Controllers
{
    [Route("api/cartItems")]
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
        [HttpGet()]
        public async Task<IActionResult> GetCartItemOverview([FromQuery] CartItemFilterModel cartItemFilterModel)
        {
            try
            {
                var result = await _cartItemService.GetCartItemOverview(cartItemFilterModel);
                var metadata = new
                {
                    result.PageSize,
                    result.CurrentPage,
                    result.TotalPages,
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{cartItemId:guid}")]
        public async Task<IActionResult> RemoveProductFromCartItem([FromRoute] Guid cartItemId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                var result = await _cartItemService.RemoveProductFromCartItem(cartItemId);
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

        [HttpPut("{cartItemId:guid}")]
        public async Task<IActionResult> AdjustCartItemQuantity([FromRoute] Guid cartItemId, [FromQuery] int quantity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                var result = await _cartItemService.AdjustCartItemQuantity(cartItemId, quantity);
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
