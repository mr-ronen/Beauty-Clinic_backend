using Microsoft.AspNetCore.Mvc;
using BeautyClinicApi.Models;
using BeautyClinicApi.Data;
using BeautyClinicApi.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using BCrypt.Net;

namespace BeautyClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationController(ApplicationDbContext context)
        {
            _context = context;
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

            var user = new User
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password), 
                FullName = userDTO.FullName,
                Role = userDTO.Role,
                ProfilePhoto = userDTO.ProfilePhoto
            };

            // Save the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Registration successful" });
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 6 && Regex.IsMatch(password, @"\d");
        }
    }
}