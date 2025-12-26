using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("[action]")]
    public async Task<List<ProductResponse>> GetAll()
    {
        var response = await _productService.GetAll();

        if (response == null)
            throw new Exception("Product not found!");

        return response;
    }

    [HttpGet("[action]/{id}")]
    public async Task<ProductResponse> Get(int id)
    {
        var response = await _productService.Get(id);

        if (response == null)
            throw new Exception("Product not found!");

        return response;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(ProductRequestDto request)
    {
        await _productService.Create(request);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<List<ProductResponse>> GetFilter([FromBody] FilterRequest request)
    {
        var response = await _productService.GetFilter(request);
        return response;
    }

    [HttpGet("[action]")]
    public async Task<ProductResponse> GetByTitle([FromQuery] string title)
    {
        var response = await _productService.GetByTitle(title);
        return response;

    }
    [HttpGet("[action]/slug")]
    public async Task<List<ProductResponse>> GetByCategory(string slug)
    {
        var response = await _productService.GetByCategory(slug);
        return response;
    }
}
