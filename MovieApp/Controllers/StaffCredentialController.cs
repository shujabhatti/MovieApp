using Microsoft.AspNetCore.Mvc;
using MovieApp.Model;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffCredentialController : ControllerBase
    {
        private readonly IStaffCredentialService _service;

        public StaffCredentialController(IStaffCredentialService service)
        {
            _service = service;
        }

        [HttpPost("postStaffCredential")]
        public IActionResult PostStaffCredential([FromBody] StaffCredential request)
        {
            try
            {
                _service.Add(request);
                return Ok("StaffCredential added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpPut("putStaffCredential")]
        public IActionResult PutStaffCredential([FromBody] StaffCredential request)
        {
            try
            {
                _service.Update(request);
                return Ok("StaffCredential updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpDelete("deleteStaffCredential")]
        public IActionResult DeleteStaffCredential(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("StaffCredential deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getStaffCredential")]
        public IActionResult GetStaffCredential(int id)
        {
            try
            {
                var response = _service.Get(id);
                if(response == null) 
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"StaffCredential not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }

        [HttpGet("getAllStaffCredentials")]
        public IActionResult GetAllStaffCredentials()
        {
            try
            {
                var response = _service.GetAll();
                if (response == null)
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = $"StaffCredential not found." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"{ex.Message} >> {ex.StackTrace}" });
            }
        }
    }
}