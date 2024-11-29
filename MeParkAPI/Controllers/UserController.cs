using MeParkAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeParkAPI.Controllers
{
    [Route("api/MePark/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationUserService _userService;

        public UserController(ApplicationUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(string id)
        {
            try
            {
                var user = _userService.GetApplicationUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                var user = _userService.GetApplicationUserById(id);

                if(user == null)
                {
                    return NotFound();
                }

                _userService.DeleteApplicationUserById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }
    }
}
