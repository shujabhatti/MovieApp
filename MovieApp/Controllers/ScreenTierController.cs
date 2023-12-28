using Microsoft.AspNetCore.Mvc;
using MovieApp.Model;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreenTierController : ControllerBase
    {
        private readonly IScreenTierService _service;

        public ScreenTierController(IScreenTierService service)
        {
            _service = service;
        }

        [HttpPost("postScreenTier")]
        public IActionResult PostScreenTier([FromBody] ScreenTier request)
        {
            try
            {
                _service.Add(request);
                return Ok("ScreenTier added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpPut("putScreenTier")]
        public IActionResult PutScreenTier([FromBody] ScreenTier request)
        {
            try
            {
                _service.Update(request);
                return Ok("ScreenTier updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpDelete("deleteScreenTier")]
        public IActionResult DeleteScreenTier(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("ScreenTier deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getScreenTier")]
        public IActionResult GetScreenTier(int id)
        {
            try
            {
                var response = _service.Get(id);
                if(response == null) 
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"ScreenTier not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getAllScreenTiers")]
        public IActionResult GetAllScreenTiers()
        {
            try
            {
                var response = _service.GetAll();
                if (response == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"ScreenTier not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }
    }
}