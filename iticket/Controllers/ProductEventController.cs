using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductEventController : Controller
{
    private readonly IProductEventService _productEventService;

    public ProductEventController(IProductEventService productEventService)
    {
        _productEventService = productEventService;
    }

    [HttpGet("[action]")]
    public async Task<List<ProductEventResponse>> GetAll()
    {
        var response = await _productEventService.GetAll();

        if (response == null)
            throw new Exception("ProductEvent not found!");

        return response;
    }

    [HttpGet("[action]/{id}")]
    public async Task<ProductEventResponse> Get(int id)
    {
        var response = await _productEventService.Get(id);

        if (response == null)
            throw new Exception("ProductEvent not found!");

        return response;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductEventRequestDto request)
    {
        await _productEventService.Create(request);
        return Ok();
    }
}
