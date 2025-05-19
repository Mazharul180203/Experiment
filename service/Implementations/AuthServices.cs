using MyApp.Data;
using MyApp.Models;
using System.Threading.Tasks;
using BCrypt.Net;
using MyApp.Services.Interfaces;
using System;

namespace MyApp.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly MyAppContext _context;

        public AuthServices(MyAppContext context)
        {
            _context = context;
        }

        public async Task RegisterUser(RegisterDto registerDto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == registerDto.Username))
            {
                throw new Exception("Username is already taken.");
            }

            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
            {
                throw new Exception("Email is already registered.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}