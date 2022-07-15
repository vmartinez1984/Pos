using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Api.Helpers;
using Pos.Core.Dtos;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class SalesController : ControllerBase
{


    private readonly ILogger<ProductsController> _logger;
    private readonly IUnitOfWorkBl _unitOfWorkBl;

    public SalesController(
        ILogger<ProductsController> logger,
        IUnitOfWorkBl unitOfWorkBl
    )
    {
        _logger = logger;
        _unitOfWorkBl = unitOfWorkBl;
    }

    [HttpGet]
    public async Task<IActionResult> StartSale()
    {
        SaleDtoIn saleDtoIn;

        saleDtoIn = new SaleDtoIn
        {
            UserId = SessionHelper.GetNameIdentifier(User)
        };
        saleDtoIn.Id = await _unitOfWorkBl.Sale.StartAsync(saleDtoIn);

        return Created($"/Sales/{saleDtoIn.Id}", new { Id = saleDtoIn.Id });
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductSaleDtoIn product)
    {
        SaleDto sale;

        sale = await _unitOfWorkBl.Sale.AddProduct(product);

        return Ok(sale);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        SaleDto sale;

        sale = await _unitOfWorkBl.Sale.GetAsync(id);

        return Ok(sale);
    }
}
