using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Expection;
using Iticket.Business.Service.Interfaces;
using Iticket.Business.Token.Implementations;
using Iticket.Business.Token.Interfaces;
using Iticket.Core.Entities;
using Iticket.Core.Enums;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public async Task Register([FromBody] RegisterRequestDto register)
    {
        await _authService.Register(register);
    }

   
    [HttpPost("login")]
    public async Task<LoginResponse> Login([FromBody] LoginRequestDto login)
    {
        return await _authService.Login(login);
    }



    [HttpPost("createroles")]
    public async Task CreateRoles()
    {
        await _authService.CreateRoles();
    }
}
