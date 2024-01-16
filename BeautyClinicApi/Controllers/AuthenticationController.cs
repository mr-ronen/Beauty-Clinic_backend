using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BeautyClinicApi.Models;
using BeautyClinicApi.Data;
using System.Linq;
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
        public async Task<IActionResult> RegisterUser([FromBody] User userModel)
        {
            // Basic validation
            if (userModel == null)
            {
                return BadRequest("User data is required.");
            }

            // Check for unique username and email
            var userExists = await _context.Users.AnyAsync(u => u.Username == userModel.Username || u.Email == userModel.Email);
            if (userExists)
            {
                return BadRequest("Username or email already in use.");
            }

            // Validate password criteria (6 characters,at least 1 number)
            if (!IsValidPassword(userModel.Password))
            {
                return BadRequest("Password does not meet the criteria.");
            }

            // Hash the password
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);

            // Save the user to the database
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Registration successful" });
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 6 && Regex.IsMatch(password, @"\d");
        }
    }
}
