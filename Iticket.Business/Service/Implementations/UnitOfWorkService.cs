using AutoMapper;
using Iticket.Business.Service.Implementations;
using Iticket.Business.Service.Interfaces;
using Iticket.Business.Token.Implementations;
using Iticket.Business.Token.Interfaces;
using Iticket.Core;
using Iticket.Core.Entities;
using Iticket.Core.Interfaces;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Data.Implementations;

public class UnitOfWorkService : IUnitOfWorkService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private IUserService _userService;
    private ITicketService _ticketService;
    private ICategoryService _categoryService;
    private IHallService _hallService;
    private IProductEventService _productEventService;
    private IProductService _productService;
    private ISectorService _sectorService;
    private IVenueService _venueService;
    private IBasketService _basketService;
    private IWishlistService _wishlistService;
    private IAuthService _authService;
    private IMailSendService _mailSendService;
    private IJwtService _jwtService;
    private IMemoryCache _memoryCache;
    private RoleManager<IdentityRole> _roleManager;

    public UnitOfWorkService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IUserService UserService => _userService ??= new UserService(_unitOfWork, _mapper, _userManager);
    public ICategoryService CategoryService => _categoryService ??= new CategoryService(_unitOfWork, _mapper);
    public IHallService HallService => _hallService ??= new HallService(_unitOfWork, _mapper);
    public IProductEventService ProductEventService => _productEventService ??= new ProductEventService(_unitOfWork, _mapper);
    public IProductService ProductService => _productService ??= new ProductService(_unitOfWork, _mapper);
    public ISectorService SectorService => _sectorService ??= new SectorService(_unitOfWork, _mapper);
    public ITicketService TicketService => _ticketService ??= new TicketService(_unitOfWork, _mapper);
    public IVenueService VenueService => _venueService ??= new VenueService(_unitOfWork, _mapper);
    public IBasketService BasketService => _basketService ??= new BasketService(_unitOfWork, _mapper);
    public IWishlistService WishlistService => _wishlistService ??= new WishlistService(_unitOfWork, _mapper);

}