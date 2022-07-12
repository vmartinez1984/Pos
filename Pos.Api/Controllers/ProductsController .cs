using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Api.Helpers;
using Pos.Core.Dtos;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{


    private readonly ILogger<ProductsController> _logger;
    private readonly IUnitOfWorkBl _unitOfWorkBl;

    public ProductsController(
        ILogger<ProductsController> logger,
        IUnitOfWorkBl unitOfWorkBl
    )
    {
        _logger = logger;
        _unitOfWorkBl = unitOfWorkBl;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<ProductDto> list;

        list = await _unitOfWorkBl.Product.GetAsync();

        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductDtoIn item)
    {
        string id;

        item.UserId = SessionHelper.GetNameIdentifier(User);
        id = await _unitOfWorkBl.Product.AddAsync(item);

        return Created("", new { Id = id });
    }

    [HttpGet("{codeBar}")]
    
    public async Task<IActionResult> Get(string codeBar)
    {
        ProductDto item;

        item = await _unitOfWorkBl.Product.GetAsync(codeBar);

        return Ok(item);
    }
}
