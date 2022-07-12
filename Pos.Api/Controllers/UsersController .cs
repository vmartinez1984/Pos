using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Api.Helpers;
using Pos.Core.Dtos;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{


    private readonly ILogger<UsersController> _logger;
    private readonly IUnitOfWorkBl _unitOfWorkBl;

    public UsersController(ILogger<UsersController> logger,
    IUnitOfWorkBl unitOfWorkBl)
    {
        _logger = logger;
        _unitOfWorkBl = unitOfWorkBl;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        List<UserDto> list;

        list = await _unitOfWorkBl.User.GetAsync();

        return Ok(list);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(UserDtoIn user)
    {
        string id;

        user.UserId = SessionHelper.GetNameIdentifier(User);
        id = await _unitOfWorkBl.User.AddAsync(user);

        return Created("", new { Id = id });
    }

}
