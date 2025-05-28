using Service.Interfaces;
using System.Threading.Tasks;
using MyApp.Models;
using Microsoft.EntityFrameworkCore;
using API.Dto;
using MyApp.Models;
using System;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.Extensions.Caching.Distributed;
using MyApp.Data;
using Microsoft.Win32;

namespace Service.Implementation
{
    public class AuthService : IAuthService
    {

        private readonly MyAppContext _context;

        public AuthService(MyAppContext context)
        {
            _context = context;
        }

        public async Task<object> AddCreateRequest(RegisterDto data)
        {
            try
            {
                if (await _context.Register.AnyAsync(u => u.email == data.email))
                {
                    return ("User is already exist!");
                }

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(data.password_hash);

                var userRegister = new RegisterDto
                {
                    username = data.username,
                    email = data.email,
                    password_hash = passwordHash,
                    created_at = DateTime.Now,
                    last_login = DateTime.Now,
                    updated_at = DateTime.Now
                    
                };

                _context.Register.Add(userRegister);
                await _context.SaveChangesAsync();
                return ("User registered successfully.");
            }
            catch (Exception ex)
            {
                return ($"An error occurred: {ex.Message}");
            }
        }
    }
}