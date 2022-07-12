using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Api.Services;
using Pos.Core.Dtos;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Api.Controllers;

// public class Jwt
// {
//     public string Password { get; set; }
//     public string Issuer { get; set; }
//     public string Audience { get; set; }
//     public int Expires { get; set; }
// }

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{


    private readonly ILogger<UsersController> _logger;
    private readonly IUnitOfWorkBl _unitOfWorkBl;
    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;

    public LoginController(
        ILogger<UsersController> logger,
        IUnitOfWorkBl unitOfWorkBl,
        IConfiguration configuration,
        IAuthService authService
    )
    {
        _logger = logger;
        _unitOfWorkBl = unitOfWorkBl;
        _configuration = configuration;
        _authService = authService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post(UserLoginDtoIn user)
    {
        UserDto userDto;

        userDto = await _unitOfWorkBl.User.LoginAsync(user);

        if (userDto is not null)
        {
            var fechaActual = DateTime.UtcNow;
            var validez = TimeSpan.FromHours(1);
            var fechaExpiracion = fechaActual.Add(validez);

            var token = _authService.GenerateToken(fechaActual, userDto, validez);
            return Ok(new
            {
                Token = token,
                ExpireAt = fechaExpiracion
            });
        }

        return StatusCode(401);
    }


}
