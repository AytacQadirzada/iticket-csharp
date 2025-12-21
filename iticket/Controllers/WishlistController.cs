using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WishlistController : Controller
{
    private readonly IWishlistService _wishlistService;

    public WishlistController(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    [HttpGet("[action]/{userId}")]
    public async Task<WishlistResponse> Get(string userId)
    {
        return await _wishlistService.Get(userId);
    }

    [HttpPost("[action]")]
    public async Task AddOrRemoveItem([FromQuery] string userId, [FromQuery] int productId){
        await _wishlistService.AddOrRemoveItem(userId, productId);
    }



}
