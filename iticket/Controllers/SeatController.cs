using Iticket.Business.Dto.Request;
using Iticket.Business.Dto.Response;
using Iticket.Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeatController : Controller
{
    private readonly ISeatService _seatService;

    public SeatController(ISeatService seatService)
    {
        _seatService = seatService;
    }

    [HttpGet("[action]")]
    public async Task<List<SeatResponse>> GetAll()
    {
        var response = await _seatService.GetAll();

        if (response == null)
            throw new Exception("Seat not found!");

        return response;
    }

    [HttpGet("[action]/{id}")]
    public async Task<SeatResponse> Get(int id)
    {
        var response = await _seatService.Get(id);

        if (response == null)
            throw new Exception("Seat not found!");

        return response;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SeatRequestDto request)
    {
        await _seatService.Create(request);
        return Ok();
    }
}
