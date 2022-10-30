using _2035Cars_Application.Commands;
using _2035Cars_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers;

[ApiController]
public class EmployeeController : ApiControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        this._service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAccount([FromBody] LoginRequestAccount command)
    {
        var tokens = await this._service.Login(command.EmailAddress!, command.Password!);

        return Ok(tokens);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAccount([FromBody] RegisterRequestAccount command)
    {
        var tokens = await _service.RegisterAccount(command);
        return Created(string.Empty, tokens);
    }

    [HttpPost("refreshtoken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokensRequest command)
    {
        var tokens = await this._service.RefreshJwtToken(command.RefreshToken!);

        return Ok(tokens);
    }

}