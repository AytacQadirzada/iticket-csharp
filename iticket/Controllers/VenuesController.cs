using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;


[Route("api/[controller]")]
[ApiController]
public class VenuesController : Controller
{
    private readonly IVenuesService _venuesService;

    public VenuesController(IVenuesService venuesService)
    {
        _venuesService = venuesService;
    }

    [HttpGet("[action]")]
    public async Task<List<VenuesResponse>> GetAll()
    {
        var response = await _venuesService.GetAll();

        if (response == null)
            throw new Exception("Venues not found!");

        return response;
    }

    [HttpGet("[action]/{id}")]
    public async Task<VenuesResponse> Get(int id)
    {
        var response = await _venuesService.Get(id);

        if (response == null)
            throw new Exception("Venues not found!");

        return response;
    }

    [HttpPost]
    public async Task<IActionResult> Create(VenuesRequestDto request)
    {
        await _venuesService.Create(request);
        return Ok();
    }
}
