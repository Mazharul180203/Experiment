using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using System;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.Extensions.Caching.Distributed;
using Data.Dto;
using Data.DBContexts;
using Data.Dto;
using Service.Interfaces;
using Service.Implementation;   

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : API.Controllers.ControllerBase
    {
        private readonly MyAppContext _context;
        private readonly IAuthService service;
        

        public RegisterController(MyAppContext context, IAuthService _service)
        {
            _context = context;
            service = _service;
        }

        [HttpPost("create/register")]
        public async Task<IActionResult> CreateRegister([FromBody] RegisterDto data)
        {

            try
            {
                return await getResponse(await service.AddCreateRequest(data));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
 
        }
    }

   
}