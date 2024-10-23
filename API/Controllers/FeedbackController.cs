using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using Services.Models.CartModels;
using Services.Services;
using Services.Models.FeedBackModels;

namespace API.Controllers
{
    [Route("api/feedbacks")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedBackService _feedBackService;

        public FeedbackController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }

        [HttpPost()]
        //[Authorize(Roles = "User, Expert")]
        public async Task<IActionResult> Create([FromForm] FeedBackCreateModel feedBackCreateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }
                var result = await _feedBackService.Create(feedBackCreateModel);
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
        public async Task<IActionResult> GetFeedBacks([FromQuery] FeedBackFilterModel feedBackFilterModel)
        {
            try
            {
                var result = await _feedBackService.GetFeedBacks(feedBackFilterModel);
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
    }
}
