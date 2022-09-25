using _2035Cars_Core.Domain;
using _2035Cars_Core.ValueObjects;

namespace Test.CoreTests.Domain
{
    public class ClientTests
    {
        private Account account;
        private Address address;
        private Person person;

        [SetUp]
        public void Setup()
        {
            this.account = new Account("TestEmail@gmail.com", "bsdkbvddbadjabdbda");
            this.address = new Address("street", "444", "city", "1212-121-22");
            this.person = new Person("FirstName", "SurName", "123456789");
        }

        [Test]
        public void CreateClient_IncorrectData_AccountIsNull_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Client client1 = new Client(null!, address, person);
            });
        }

        [Test]
        public void CreateClient_IncorrectData_AddressIsNull_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Client client1 = new Client(account, null!, person);
            });
        }

        [Test]
        public void CreateClient_IncorrectData_PersonIsNull_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Client client1 = new Client(account, address, null!);
            });
        }

        [Test]
        public void CreateClient_CorrectData_ShouldCreateNewInstanceOfClient()
        {
            // Act
            Client newClient = new Client(account, address, person); 

            // Assert
            Assert.IsInstanceOf<Client>(newClient);
            Assert.NotNull(newClient);
        }
    }
}