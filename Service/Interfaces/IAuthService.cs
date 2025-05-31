using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dto;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        public Task<object> AddCreateRequest(RegisterDto data);
    }
}
