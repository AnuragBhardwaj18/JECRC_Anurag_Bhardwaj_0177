using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace JwtRoleAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("dashboard")]
        [Authorize(Roles = "User")]
        public IActionResult GetUserDashboard()
        {
            return Ok("Welcome to User dashboard. Only users with user role can see this.");
        }   
    }
}