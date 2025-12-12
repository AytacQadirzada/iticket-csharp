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
public class AuthController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMemoryCache _cache;
    private readonly IMailSendService mailSend;

    public AuthController(UserManager<User> userManager, IJwtService jwtService, AppDbContext context, RoleManager<IdentityRole> roleManager, IMemoryCache cache, IMailSendService mailSend)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _context = context;
        _roleManager = roleManager;
        _cache = cache;
        this.mailSend = mailSend;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> Register([FromBody] RegisterRequestDto register)
    {
        User isEmailExsist = await _userManager.FindByEmailAsync(register.Email);
        if (isEmailExsist != null)
        {
            return StatusCode(StatusCodes.Status403Forbidden, new { status = "error", message = "Email is already exisit" });
        }

        string userName = $"{register.FirstName}.{register.LastName}.{register.Phone.Trim('+')}";
        User user = new()
        {
            FirstName = register.FirstName,
            LastName = register.LastName,
            Email = register.Email,
            UserName = userName,
            Phone = register.Phone,
            Gender = register.Gender,
            CreatedDate = DateTime.UtcNow.AddHours(4)
        };
        IdentityResult result = await _userManager.CreateAsync(user, register.Password);
        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { status = error.Code, message = error.Description });
            }
        };

        await _userManager.AddToRoleAsync(user, Roles.User.ToString());
        return Ok(new { statsu = "Success", message = "Confirmation email sent" });
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequestDto login)
    {
        User user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null) return NotFound();
        if (!await _userManager.CheckPasswordAsync(user, login.Password)) return Unauthorized();
        var roles = _userManager.GetRolesAsync(user).Result;
        var jwtToken = _jwtService.GetJwt(user, roles);
        //var userData = new JwtUserDataDto
        //{
        //    Id = user.Id,
        //    Username = login.Username,
        //    Email = user.Email,
        //};

        return Ok(new
        {
            token = jwtToken,
            //user = userData,
        });
    }



    [HttpPost("[action]")]
    public async Task<IActionResult> SendOtpAsync([FromQuery] string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Email daxil edilməyib");
        }
        User user = await _userManager.FindByEmailAsync(email);

        if ( user == null)
        {
            return NotFound("İstifadəçi tapılmadı");
        }
        string otp = new Random().Next(100000, 999999).ToString();

        _cache.Set(email, otp, TimeSpan.FromMinutes(5));

        mailSend.SendEmail(email, otp);

        return Ok("OTP kodunuz göndərildi");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> VerifyOtp([FromQuery] string email, string otp)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Email daxil edilməyib");
        }
        User user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return NotFound("İstifadəçi tapılmadı");
        }
        if (_cache.TryGetValue(email, out string cachedOtp))
        {
            if (cachedOtp == otp)
            {
                user.IsEmailVerified = true;
                await _userManager.UpdateAsync(user);
                _cache.Remove(email);

                return Ok("OTP təsdiqləndi");
            }

            throw new OtpMismatchException();
        }
        return BadRequest("OTP kodun vaxtı bitib!");
    }
    


    //[HttpPost("createroles")]
    //public async Task CreateRoles()
    //{
    //    foreach (var item in Enum.GetValues(typeof(Roles)))
    //    {
    //        if (!(await _roleManager.RoleExistsAsync(item.ToString())))
    //        {
    //            await _roleManager.CreateAsync(new IdentityRole
    //            {
    //                Name = item.ToString()
    //            });
    //        }
    //    }
    //}
}
