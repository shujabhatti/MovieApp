using Microsoft.AspNetCore.Mvc;
using MovieApp.Model;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost("postCustomer")]
        public IActionResult PostCustomer([FromBody] MyCustomer request)
        {
            try
            {
                _service.Add(request);
                return Ok("Customer added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpPut("putCustomer")]
        public IActionResult PutCustomer([FromBody] MyCustomer request)
        {
            try
            {
                _service.Update(request);
                return Ok("Customer updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpDelete("deleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Customer deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getCustomer")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var response = _service.Get(id);
                if(response == null) 
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"Customer not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var response = _service.GetAll();
                if (response == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"Customer not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }
    }
}