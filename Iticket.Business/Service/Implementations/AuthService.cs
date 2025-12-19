using AutoMapper;
using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Expection;
using Iticket.Business.Service.Interfaces;
using Iticket.Business.Token.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Core.Enums;
using Iticket.Data;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Iticket.Business.Service.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMemoryCache _cache;
    private readonly IMailSendService mailSend;
    private readonly IMapper _mapper;

    public AuthService(UserManager<User> userManager, IJwtService jwtService, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager, IMemoryCache cache, IMailSendService mailSend)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
        _roleManager = roleManager;
        _cache = cache;
        this.mailSend = mailSend;
    }
    public async Task Register([FromBody] RegisterRequestDto register)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        User isEmailExsist = await _userManager.FindByEmailAsync(register.Email);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        if (isEmailExsist != null)
        {
            throw new AuthException("Bu email artıq istifadə olunub!", StatusCodes.Status400BadRequest);
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
            throw new NotFoundException();

        List<BasketItem> basketItems = new List<BasketItem>();
        Basket basket = new Basket()
        {
            BasketItems = basketItems,
            TotalPrice = 0,
        };

        user.Basket = basket;

        List<Product> products = new List<Product>();
        Wishlist wishlist = new Wishlist()
        {
            Products = products
        };

        user.Wishlist = wishlist;

        await _userManager.AddToRoleAsync(user, Roles.User.ToString());
    }


    public async Task<LoginResponse> Login([FromBody] LoginRequestDto login)
    {
        User user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null) throw new NotFoundException("User not found");
        if (!await _userManager.CheckPasswordAsync(user, login.Password))
            throw new AuthException(
                "Email və ya şifrə yalnışdır!",
                StatusCodes.Status401Unauthorized);
        var roles = _userManager.GetRolesAsync(user).Result;
        var jwtToken = _jwtService.GetJwt(user, roles);

#pragma warning disable CS8601 // Possible null reference assignment.
        return new LoginResponse
        {
            Token = jwtToken,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
#pragma warning restore CS8601 // Possible null reference assignment.
    }
    public UserManager<User> Get_userManager()
    {
        return _userManager;
    }


}
