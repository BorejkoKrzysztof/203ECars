using _2035Cars_Infrastructure.Commands.Account;
using _2035Cars_Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers;

[ApiController]
public class AccountController : Controller
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        this._service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAccount([FromBody] LoginRequestAccount command)
    {


        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAccount([FromBody] RegisterRequestAccount command)
    {
        await _service.RegisterAccount(command.FirstName!, command.LastName!, command.EmailAddress!,
                                            command.Password!, command.ConfirmPassword!);
        return Created(string.Empty, null);
    }

    [HttpPost("refresh-tokens")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokensRequest command)
    {


        return Ok();
    }

}