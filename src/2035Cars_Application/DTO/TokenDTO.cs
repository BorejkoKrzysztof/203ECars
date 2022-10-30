namespace _2035Cars_Application.DTO;

public class TokenDTO : JwtDTO
{
    public string RefreshToken { get; set; }
    public string Role { get; set; }
}