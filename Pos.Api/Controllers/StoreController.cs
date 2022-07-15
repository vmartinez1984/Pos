using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Api.Helpers;
using Pos.Core.Dtos;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class StoreController : ControllerBase
{


    private readonly ILogger<ProductsController> _logger;
    private readonly IUnitOfWorkBl _unitOfWorkBl;

    public StoreController(
        ILogger<ProductsController> logger,
        IUnitOfWorkBl unitOfWorkBl
    )
    {
        _logger = logger;
        _unitOfWorkBl = unitOfWorkBl;
    }

    [HttpPost]
    public async Task<IActionResult> Post(StoreDtoIn item)
    {
        string id;

        item.UserId = SessionHelper.GetNameIdentifier(User);
        id = await _unitOfWorkBl.Store.AddAsync(item);

        return Created($"/Store/{id}", new { Id = id });
    }

    [HttpGet("{barcode}")]
    public async Task<IActionResult> Get(string barcode)
    {
        var response = await _unitOfWorkBl.Store.GetAsync(barcode);

        return Ok(response);
    }
}//end class