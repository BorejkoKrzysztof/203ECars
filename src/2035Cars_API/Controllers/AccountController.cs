// using _2035Cars_Infrastructure.Commands.Account;
// using _2035Cars_Infrastructure.Services;
// using Microsoft.AspNetCore.Mvc;
// using MyTasks.Api.Controllers;

// namespace _2035Cars_API.Controllers;

// [ApiController]
// public class AccountController : Controller
// {
//     private readonly IAccountService _service;

//     public AccountController(IAccountService service)
//     {
//         this._service = service;
//     }

//     [HttpPost("login")]
//     public async Task<IActionResult> LoginAccount([FromBody] LoginRequestAccount command)
//     {
//         var tokens = await this._service.Login(command.EmailAddress!, command.Password!);

//         return Ok(tokens);
//     }

//     [HttpPost("register")]
//     public async Task<IActionResult> RegisterAccount([FromBody] RegisterRequestAccount command)
//     {
//         var tokens = await _service.RegisterAccount(command.FirstName!, command.LastName!, command.EmailAddress!,
//                                             command.Password!, command.ConfirmPassword!);
//         return Created(string.Empty, tokens);
//     }

//     [HttpPost("refreshtoken")]
//     public async Task<IActionResult> RefreshToken([FromBody] RefreshTokensRequest command)
//     {
//         var tokens = await this._service.RefreshJwtToken(command.RefreshToken!);

//         return Ok(tokens);
//     }

// }