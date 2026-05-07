using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute]int id, [FromQuery] string mode)
        {
            try
            {
                _userService.DeleteUser(id, mode);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

 
    }
}
