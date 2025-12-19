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

    [HttpGet("[action]/{id}")]
    public async Task<WishlistResponse> Get( int id)
    {
        return await _wishlistService.Get(id);
    }

    [HttpPost("[action]")]
    public async Task AddItem([FromQuery] int wishlistId, [FromQuery] int productId){
        await _wishlistService.AddItem(wishlistId, productId);
    }

    [HttpPost("[action]")]
    public async Task RemoveItem([FromQuery] int wishlistId,[FromQuery] int productId)
    {
        await _wishlistService.RemoveItem(wishlistId, productId);
    }


}
