using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace JwtRoleAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        [HttpGet("dashboard")]
        [Authorize(Roles = "Manager")]    
        public IActionResult GetManagerDashboard()
        {
            return Ok("This is sensitive data only for Managers.");
        }   

        [HttpGet("reports")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult GetReports()
        {
            return Ok("These are the reports for Managers.");
        }
    }
}