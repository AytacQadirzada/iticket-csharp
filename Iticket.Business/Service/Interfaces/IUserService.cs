using Iticket.Business.Expection;
using Iticket.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Business.Service.Interfaces
{
    public interface IUserService
    {
        Task SendOtpAsync([FromQuery] string email);
        Task VerifyOtp([FromQuery] string email, string otp);
    }
}
