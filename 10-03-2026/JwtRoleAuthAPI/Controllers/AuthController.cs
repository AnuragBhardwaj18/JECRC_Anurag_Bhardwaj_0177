using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using JwtRoleAuthAPI.Data;
using JwtRoleAuthAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace JwtRoleAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
            
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
                return BadRequest("Username already exists.");

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null)
                return Unauthorized("Invalid credentials.");

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });

        }
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: creds); 
            return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }
}