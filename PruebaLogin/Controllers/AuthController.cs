using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PRUEBALOGIN.Data; 
using PRUEBALOGIN.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PRUEBALOGIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsersContext _context;
        public AuthController(UsersContext context)
        { 
            _context = context;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            
            var userExisting = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
            if (userExisting == null)
            {
                return BadRequest("Solicitu no valida");
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mjncjchuebfyfy4db4fy4fybfuf4uhfud4nd41"));
            var singninCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5152",
                audience: "https://localhost:5152",
                claims : new List<Claim>(),
                expires : DateTime.Now.AddMonths(1),
                signingCredentials: singninCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new Authenticated {Token = tokenString}); 
        }
            
}
}