using _2035Cars_Core.ValueObjects;

namespace Test.CoreTests.ValueObjects
{
    public class PersonTests
    {
        private string firstName;
        private string lastName;
        private string phoneNumber;

        [SetUp]
        public void Setup()
        {
            this.firstName = "FirstName";
            this.lastName = "LastName";
            this.phoneNumber = "123456789";
        }

        [Test]
        public void CreatePerson_IncorrectData_FirstNameIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Person person = new Person(string.Empty, lastName, phoneNumber);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Person person = new Person(null!, lastName, phoneNumber);
            });
        }

        [Test]
        public void CreatePerson_IncorrectData_LastNameIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Person person = new Person(firstName, string.Empty, phoneNumber);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Person person = new Person( firstName, null!, phoneNumber);
            });
        }

        [Test]
        public void CreatePerson_IncorrectData_PhoneNumberIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Person person = new Person(firstName, lastName, string.Empty);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Person person = new Person( firstName, lastName, null!);
            });
        }


        [Test]
        public void CreatePerson_CorrectData_ShouldReturnNewInstanceOfPerson()
        {
            // Act
            Person person = new Person(firstName, lastName, phoneNumber);

            // Assert
            Assert.IsInstanceOf<Person>(person);
            Assert.NotNull(person);
        }
    }
}