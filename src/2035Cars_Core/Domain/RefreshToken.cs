using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace _2035Cars_Core.Domain;

public class RefreshToken : BaseEntity
{
    [Required]
    public Guid UserId { get; private set; }

    [Required]
    public string Token { get; private set; }

    [Required]
    public DateTime ExpiryDate { get; private set; }

    private RefreshToken()
    {
    }

    public static RefreshToken CreateRefreshToken(Guid userId)
    {
        return new RefreshToken
        {
            // Id = Guid.NewGuid(),
            UserId = userId,
            Token = WriteRefreshToken(),
            ExpiryDate = DateTime.UtcNow.AddMonths(1),
            };
    }

    private static string WriteRefreshToken()
    {
        string result;
        var randomNumbers = new byte[32];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumbers);
            result = Convert.ToBase64String(randomNumbers);
        }

        return result;
    }
}