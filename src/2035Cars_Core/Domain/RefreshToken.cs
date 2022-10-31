using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace _2035Cars_Core.Domain
{
    public class RefreshToken : BaseEntity
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public RefreshToken()
        {

        }


        public static RefreshToken CreateRefreshToken(long userId)
        {
            return new RefreshToken
            {
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
}