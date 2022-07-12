using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dtos;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{


    private readonly ILogger<UsersController> _logger;
    private readonly IUnitOfWorkBl _unitOfWorkBl;

    public RolesController(ILogger<UsersController> logger,
    IUnitOfWorkBl unitOfWorkBl)
    {
        _logger = logger;
        _unitOfWorkBl = unitOfWorkBl;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<RoleDto> list;

        list = await _unitOfWorkBl.Role.GetAsync();

        return Ok(list);
    }

   

}
