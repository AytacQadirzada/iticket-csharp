using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Expection;
using Iticket.Core.Entities;
using Iticket.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Interfaces
{
    public interface IAuthService
    {
        Task Register(RegisterRequestDto register);
        Task<LoginResponse> Login(LoginRequestDto login);
        Task CreateRoles();
    }
}
