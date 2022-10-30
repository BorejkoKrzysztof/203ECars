using _2035Cars_Application.DTO;
using _2035Cars_Core.Enums;

namespace _2035Cars_Infrastructure.Services;

public interface IJwtHandler
{
    JwtDTO CreateToken(long userId, string emailAddress, BuisnessPosition businessPosition);
}