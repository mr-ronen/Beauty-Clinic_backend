using Microsoft.AspNetCore.Mvc;
using BeautyClinicApi.Models;
using BeautyClinicApi.Data;
using BeautyClinicApi.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data;

namespace BeautyClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO userDTO)
        {
            // Basic validation
            if (userDTO == null)
            {
                return BadRequest("User data is required.");
            }

            // Check for unique username and email
            var userExists = await _context.Users.AnyAsync(u => u.Username == userDTO.Username || u.Email == userDTO.Email);
            if (userExists)
            {
                return BadRequest("Username or email already in use.");
            }

            // Validate password criteria (6 characters, at least 1 number)
            if (!IsValidPassword(userDTO.Password))
            {
                return BadRequest("Password does not meet the criteria.");
            }

            //when Swagger sends a "string" instead of Client, user whould be able to register as a Client by default.
            var permissibleRoles = new List<string> { "Client", "Admin", "Worker" };  
            var role = permissibleRoles.Contains(userDTO.Role) ? userDTO.Role : "Client";

           

            var user = new User
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password), 
                FullName = userDTO.FullName,
                Role = role,
                ProfilePhoto = userDTO.ProfilePhoto ?? null,

            };

            // Save the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Registration successful" });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDTO loginDTO)
        {
            if (loginDTO == null || string.IsNullOrEmpty(loginDTO.Username) || string.IsNullOrEmpty(loginDTO.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginDTO.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
            {
                return Unauthorized("Invalid login attempt.");
            }

            var token = GenerateJwtToken(user);

            return Ok(new { token, user.Username });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
             {
              new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
              new(ClaimTypes.Name, user.Username)
              // Add more claims as needed
             };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["Jwt:ExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static bool IsValidPassword(string password)
        {
            return password.Length >= 6 && Regex.IsMatch(password, @"\d");
        }




    }
}