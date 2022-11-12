using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using _2035Cars_Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Api.Controllers;

namespace _2035Cars_API.Controllers;

[ApiController]
public class EmployeeController : ApiControllerBase
{
    private readonly IEmployeeService _service;
    const int pageSize = 10;

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
        return Ok(tokens);
    }

    [HttpPost("refreshtoken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokensRequest command)
    {
        var tokens = await this._service.RefreshJwtToken(command.RefreshToken!);

        return Ok(tokens);
    }

    [Authorize]
    [HttpGet("getallrentalemployees/{rentalId}/{currentPage}")]
    public async Task<IActionResult> GetEmployeesListForRental([FromRoute] long rentalId,
                                                                    [FromRoute] int currentPage)
    {
        EmployeesCollectionWithPagination employeesWithPagination = await this._service
                                                    .GetEmployeeLists(rentalId, currentPage, pageSize);

        if (employeesWithPagination is null)
            return BadRequest();

        return Ok(employeesWithPagination);
    }

    [Authorize]
    [HttpGet("getemployeedetails/{employeeId}")]
    public async Task<IActionResult> GetEmployeeDetails([FromRoute] long employeeId)
    {
        EmployeeDetailsDTO employeeDetails = await this._service
                                                            .GetEmployeeDetails(employeeId);

        if (employeeDetails is null)
            return BadRequest();

        return Ok(employeeDetails);
    }

    [Authorize]
    [HttpDelete("removeemployee/{employeeId}")]
    public async Task<IActionResult> RemoveEmployee([FromRoute] long employeeId)
    {
        bool result = await this._service.RemoveEmployeeAsync(employeeId);

        if (!result)
            return BadRequest();

        return NoContent();
    }

}