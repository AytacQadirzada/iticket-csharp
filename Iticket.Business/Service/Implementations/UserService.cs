using AutoMapper;
using Iticket.Business.Expection;
using Iticket.Business.Service.Interfaces;
using Iticket.Business.Token.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Business.Service.Implementations;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMemoryCache _cache;
    private readonly IMailSendService mailSend;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task SendOtpAsync([FromQuery] string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new AuthException("Email daxil edilməyib", StatusCodes.Status400BadRequest);
        }
        User user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            throw new NotFoundException("İstifadəçi tapılmadı");
        }
        string otp = new Random().Next(100000, 999999).ToString();

        _cache.Set(email, otp, TimeSpan.FromMinutes(5));

        mailSend.SendEmail(email, otp);
    }
    public async Task VerifyOtp([FromQuery] string email, string otp)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new AuthException("Email daxil edilməyib", StatusCodes.Status400BadRequest);
        }
        User user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            throw new NotFoundException("İstifadəçi tapılmadı");
        }
        if (_cache.TryGetValue(email, out string cachedOtp))
        {
            if (cachedOtp == otp)
            {
                user.IsEmailVerified = true;
                await _userManager.UpdateAsync(user);
                _cache.Remove(email);
            }

            throw new OtpMismatchException();
        }
        throw new AuthException("OTP kodun vaxtı bitib!", StatusCodes.Status400BadRequest);
    }
    public UserManager<User> Get_userManager()
    {
        return _userManager;
    }

}
