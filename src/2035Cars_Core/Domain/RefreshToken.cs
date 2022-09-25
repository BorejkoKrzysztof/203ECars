using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace _2035Cars_Core.Domain
{
    public class RefreshToken : BaseEntity
    {
        [Required]
        public long UserId { get; private set; }

        [Required]
        public string Token { get; private set; }

        [Required]
        public DateTime ExpiryDate { get; private set; }

        public RefreshToken()
        {
            
        }

        
        public RefreshToken(long userId, string token)
        {
            UserId = userId;
            Token = string.IsNullOrEmpty(token) ? throw new ArgumentNullException(nameof(token)) : token;
            ExpiryDate = ExpiryDate = DateTime.UtcNow.AddMonths(1);
            // CreatedDate = DateTime.UtcNow;
            // LastUpdateDate = DateTime.UtcNow;
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
}