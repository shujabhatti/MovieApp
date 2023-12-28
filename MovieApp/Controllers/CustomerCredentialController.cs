using Microsoft.AspNetCore.Mvc;
using MovieApp.Model;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerCredController : ControllerBase
    {
        private readonly ICustomerCredService _service;

        public CustomerCredController(ICustomerCredService service)
        {
            _service = service;
        }

        [HttpPost("postCustomerCred")]
        public IActionResult PostCustomerCred([FromBody] CustomerCred request)
        {
            try
            {
                _service.Add(request);
                return Ok("CustomerCred added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpPut("putCustomerCred")]
        public IActionResult PutCustomerCred([FromBody] CustomerCred request)
        {
            try
            {
                _service.Update(request);
                return Ok("CustomerCred updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpDelete("deleteCustomerCred")]
        public IActionResult DeleteCustomerCred(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("CustomerCred deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getCustomerCred")]
        public IActionResult GetCustomerCred(int id)
        {
            try
            {
                var response = _service.Get(id);
                if(response == null) 
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"CustomerCred not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getAllCustomerCreds")]
        public IActionResult GetAllCustomerCreds()
        {
            try
            {
                var response = _service.GetAll();
                if (response == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"CustomerCred not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }
    }
}