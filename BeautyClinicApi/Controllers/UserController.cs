using BeautyClinicApi.DTOs;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using BeautyClinicApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BeautyClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAll();
            var userDTOs = users.Select(user => new UserDTO
            {
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                ProfilePhoto = user.ProfilePhoto ,
                
                // Orders = user.Orders.Select(order => new OrderDTO { ... }).ToList(),
                
            }).ToList();

            return Ok(userDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return NotFound();

            var userDTO = new UserDTO
            {
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                ProfilePhoto = user.ProfilePhoto,
            };

            return Ok(userDTO);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {
            var user = new User
            {
                Username = userDTO.Username,
                Password = new PasswordHasher<User>().HashPassword(null, userDTO.Password),
                Email = userDTO.Email,
                FullName = userDTO.FullName,
                Role = userDTO.Role,
                ProfilePhoto = userDTO.ProfilePhoto,
            };

            _userRepository.Add(user);
            

            // Do not return the user directly, map it to UserDTO (excluding sensitive fields)
            var createdUserDTO = new UserDTO
            {
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                ProfilePhoto = user.ProfilePhoto,
                // Map nested collections if necessary
            };

            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, createdUserDTO);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return NotFound();

            user.Username = userDTO.Username;
            //  Password should be in a separate method 
            user.Email = userDTO.Email;
            user.FullName = userDTO.FullName;
            user.Role = userDTO.Role;
            user.ProfilePhoto = userDTO.ProfilePhoto;

            _userRepository.Update(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return NotFound();

            _userRepository.Delete(id);

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchUsers(string username, string fullName, string role)
        {
            var users = _userRepository.SearchUsers(username, fullName, role);
            var userDTOs = users.Select(user => new UserDTO
            {
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                ProfilePhoto = user.ProfilePhoto,
                // Map Orders and Appointments if necessary
            }).ToList();

            return Ok(userDTOs);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateUserRole")]
        public IActionResult UpdateUserRole([FromBody] UpdateUserRoleDto updateUserRoleDto)
        {
            var user = _userRepository.GetById(updateUserRoleDto.UserId);
            if (user == null) return NotFound("User not found.");

            if (updateUserRoleDto.NewRole != "admin" && updateUserRoleDto.NewRole != "worker" && updateUserRoleDto.NewRole != "client")
                return BadRequest("Invalid role.");

            user.Role = updateUserRoleDto.NewRole;
            _userRepository.Update(user);

            return Ok($"User role updated to {updateUserRoleDto.NewRole}");
        }
    }
}
