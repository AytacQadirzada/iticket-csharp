using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HallController : Controller
{
    private readonly IHallService _hallService;

    public HallController(IHallService hallService)
    {
        _hallService = hallService;
    }

    [HttpGet("[action]")]
    public async Task<List<HallResponse>> GetAll()
    {
        var response = await _hallService.GetAll();

        if (response == null)
            throw new Exception("Hall not found!");

        return response;
    }

    [HttpGet("[action]/{id}")]
    public async Task<HallResponse> Get(int id)
    {
        var response = await _hallService.Get(id);

        if (response == null)
            throw new Exception("Hall not found!");

        return response;
    }

    [HttpPost]
    public async Task<IActionResult> Create(HallRequestDto request)
    {
        await _hallService.Create(request);
        return Ok();
    }
}