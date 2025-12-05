using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("[action]")]
    public async Task<List<CategoryResponse>> GetAll()
    {
        var response = await _categoryService.GetAll();

        if (response == null)
            throw new Exception("Categories not found!");

        return response;
    }

    [HttpGet("[action]/{id}")]
    public async Task<CategoryResponse> Get(int id)
    {
        var response = await _categoryService.Get(id);

        if (response == null)
            throw new Exception("Categories not found!");

        return response;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryRequestDto request)
    {
        await _categoryService.Create(request);
        return Ok();
    }
}
