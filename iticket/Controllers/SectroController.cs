using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SectorController : Controller
{
    private readonly ISectorService _sectorService;

    public SectorController(ISectorService sectorService)
    {
        _sectorService = sectorService;
    }

    [HttpGet("[action]")]
    public async Task<List<SectorResponse>> GetAll()
    {
        var response = await _sectorService.GetAll();

        if (response == null)
            throw new Exception("Sector not found!");

        return response;
    }

    [HttpGet("[action]/{id}")]
    public async Task<SectorResponse> Get(int id)
    {
        var response = await _sectorService.Get(id);

        if (response == null)
            throw new Exception("Sector not found!");

        return response;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SectorRequestDto request)
    {
        await _sectorService.Create(request);
        return Ok();
    }
}
