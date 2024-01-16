using AutoMapper;
using BeautyClinicApi.DTOs;
using System.Collections.Generic;
using System.Linq;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BeautyClinicApi.Data;


namespace BeautyClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;   


        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userRepository.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId) return BadRequest();
            _userRepository.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchUsers(string username = null, string fullname = null, string role = null)
        {
            var users = _userRepository.SearchUsers(username, fullname, role);
            return Ok(users);
        }
    }
}
