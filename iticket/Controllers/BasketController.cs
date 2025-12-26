using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Iticket.Core;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet("[action]/{userId}")]
    public async Task<BasketResponse> GetAll(string userId)
    {
        BasketResponse response = await _basketService.Get(userId);
        return response;
    }

    [HttpPost("[action]")]
    public async Task AddTisket([FromBody] AddItem item)
    {
        await _basketService.AddItem(item);
    }

    [HttpDelete("[action]/{userId}/{basketItemId}")]
    public async Task RemoveTicket(string userId, int basketItemId)
    {
        await _basketService.RemoveItem(userId, basketItemId);
    }
}
