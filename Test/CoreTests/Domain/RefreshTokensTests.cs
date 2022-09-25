using _2035Cars_Core.Domain;

namespace Test.CoreTests.Domain
{
    public class RefreshTokensTests
    {
        private long userId;
        private string token;

        [SetUp]
        public void Setup()
        {
            this.userId = 87524874874L;
            this.token = "sfhvbchusdv48376874gduyc";
        }

        [Test]
        public void CreateRefreshToken_IncorrectData_TokenIsNullOrEempty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                RefreshToken refreshToken = new RefreshToken(userId, string.Empty);
            });

            Assert.Throws<ArgumentNullException>(() => {
                RefreshToken refreshToken = new RefreshToken(userId, null!);
            });
        }

        [Test]
        public void CreateRefreshToken_CorrectData_ShouldCreateNewRefreshToken()
        {
            // Act
            RefreshToken newRF = new RefreshToken(userId, token);

            // Assert
            Assert.IsInstanceOf<RefreshToken>(newRF);
            Assert.NotNull(newRF);
        }
    }
}