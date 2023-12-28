using Microsoft.AspNetCore.Mvc;
using MovieApp.Model;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowingController : ControllerBase
    {
        private readonly IShowingService _service;

        public ShowingController(IShowingService service)
        {
            _service = service;
        }

        [HttpPost("postShowing")]
        public IActionResult PostShowing([FromBody] Showing request)
        {
            try
            {
                _service.Add(request);
                return Ok("Showing added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpPut("putShowing")]
        public IActionResult PutShowing([FromBody] Showing request)
        {
            try
            {
                _service.Update(request);
                return Ok("Showing updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpDelete("deleteShowing")]
        public IActionResult DeleteShowing(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Showing deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getShowing")]
        public IActionResult GetShowing(int id)
        {
            try
            {
                var response = _service.Get(id);
                if(response == null) 
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"Showing not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getAllShowings")]
        public IActionResult GetAllShowings()
        {
            try
            {
                var response = _service.GetAll();
                if (response == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"Showing not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }
    }
}