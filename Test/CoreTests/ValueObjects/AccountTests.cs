using _2035Cars_Core.ValueObjects;

namespace Test.CoreTests.ValueObjects
{
    public class AccountTests
    {
        private string emailAddress;
        private string password;

        [SetUp]
        public void Setup()
        {
            this.emailAddress = "test@gmail.com";
            this.password = "jvfskjfvcksdcvkjdac";
        }

        [Test]
        public void CreateAccount_IncorrectData_EmailAddressIsNulOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Account account = new Account(string.Empty, password);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Account account = new Account(null!, password);
            });
        }

        [Test]
        public void CreateAccount_IncorrectData_PasswordIsNulOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Account account = new Account(emailAddress, string.Empty);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Account account = new Account(emailAddress, null!);
            });
        }

        [Test]
        public void CreateAccount_CorrectData_ShouldCreateNewAccount()
        {
            // Act
            Account account = new Account(emailAddress, password);

             // Assert
            Assert.IsInstanceOf<Account>(account);
            Assert.NotNull(account);
        }
    }
}