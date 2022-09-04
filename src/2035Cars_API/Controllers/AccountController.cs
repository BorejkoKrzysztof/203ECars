using _2035Cars_Infrastructure.Commands.Account;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers;

[ApiController]
public class AccountController : ApiControllerBase
{
    public AccountController()
    {
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAccount([FromBody] LoginRequestAccount command)
    {


        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAccount([FromBody] RegisterRequestAccount command)
    {



        return Ok();
    }

    [HttpPost("refresh-tokens")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokensRequest command)
    {


        return Ok();
    }

}