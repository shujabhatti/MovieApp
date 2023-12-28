using Microsoft.AspNetCore.Mvc;
using MovieApp.Model;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeatTypeController : ControllerBase
    {
        private readonly ISeatTypeService _service;

        public SeatTypeController(ISeatTypeService service)
        {
            _service = service;
        }

        [HttpPost("postSeatType")]
        public IActionResult PostSeatType([FromBody] SeatType request)
        {
            try
            {
                _service.Add(request);
                return Ok("SeatType added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpPut("putSeatType")]
        public IActionResult PutSeatType([FromBody] SeatType request)
        {
            try
            {
                _service.Update(request);
                return Ok("SeatType updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpDelete("deleteSeatType")]
        public IActionResult DeleteSeatType(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("SeatType deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getSeatType")]
        public IActionResult GetSeatType(int id)
        {
            try
            {
                var response = _service.Get(id);
                if(response == null) 
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"SeatType not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getAllSeatTypes")]
        public IActionResult GetAllSeatTypes()
        {
            try
            {
                var response = _service.GetAll();
                if (response == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"SeatType not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }
    }
}