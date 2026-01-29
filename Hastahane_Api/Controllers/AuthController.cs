using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastahane_Api.Controllers
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var user = _userService.Login(dto.Email, dto.Sifre);
        if (user == null) return Unauthorized();
        return Ok(user);
    }
}


