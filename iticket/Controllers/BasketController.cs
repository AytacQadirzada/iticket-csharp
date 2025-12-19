using Iticket.Core;
using Microsoft.AspNetCore.Mvc;

namespace Iticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public BasketController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
