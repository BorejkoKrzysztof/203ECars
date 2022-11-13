using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.ViewModels;

namespace _2035Cars_Application.Interfaces;

public interface IEmployeeService
{
    Task<TokenDTO> Login(string emailAddress, string password);
    Task<TokenDTO> RegisterAccount(RegisterRequestAccount command);

    Task<TokenDTO> RefreshJwtToken(string refreshToken);
    Task<EmployeesCollectionWithPagination> GetEmployeeLists(long rentalId, int currentPage, int pageSize);
    Task<EmployeeDetailsDTO> GetEmployeeDetails(long employeeId);
    Task<bool> RemoveEmployeeAsync(long employeeId);
    Task<bool> EditEmployeeAsync(EditEmployeeCommand command);
}