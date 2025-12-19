using Iticket.Business.Dto.Request;
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
public class UserConroller : Controller
{
    private readonly IUserService _userService;

    public UserConroller(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("[action]")]
    public async Task SendOtpAsync([FromQuery] string email)
    {
        await _userService.SendOtpAsync(email);
    }

    [HttpPost("[action]")]
    public async Task VerifyOtp([FromQuery] string email, string otp)
    {
        await _userService.VerifyOtp(email, otp);
    }
    
}
