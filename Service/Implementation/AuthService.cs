using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Dto;

namespace Service.Implementation
{
    public class AuthService : IAuthService
    {
        public Task<object> AddCreateRequest(RegisterDto data)
        {
            throw new NotImplementedException();
        }
    }
}
