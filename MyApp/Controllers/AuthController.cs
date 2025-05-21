using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.Extensions.Caching.Distributed;
using API.Dto;
using Service.Interfaces;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly MyAppContext _context;
        private readonly IAuthService service;
        

        public RegisterController(MyAppContext context)
        {
            _context = context;
        }

        [HttpPost("create/register")]
        public async Task<IActionResult> CreateRegister([FromBody] RegisterDto registerDto)
        {

            try
            {
                 
            }
            catch (Exception ex){return BadRequest(new { Message = ex.Message });}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if username or email already exists
            if (await _context.Register.AnyAsync(u => u.username == registerDto.username))
            {
                return BadRequest("Username is already taken.");
            }

            if (await _context.Register.AnyAsync(u => u.email == registerDto.email))
            {
                return BadRequest("Email is already registered.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.password_hash);

            var user = new User
            {
                Username = registerDto.username,
                Email = registerDto.email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            // Save user to database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User registered successfully." });
        }
    }

   
}