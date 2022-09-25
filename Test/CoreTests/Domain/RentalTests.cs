using _2035Cars_Core.Domain;
using _2035Cars_Core.ValueObjects;

namespace Test.CoreTests.Domain
{
    public class RentalTests
    {
        private string title;
        private Address address;

        [SetUp]
        public void Setup()
        {
            this.title = "Test TITLE";
            this.address = new Address("street", "23", "city", "52424-2222");
        }

        [Test]
        public void CreateRental_IncorrectData_TitleIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Rental rental = new Rental("", address);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Rental rental = new Rental(null!, address);
            });
        }

        [Test]
        public void CreateRental_CorrectData_ShouldCreateNewRental()
        {
            // Act
            Rental rental = new Rental(title, address);

            // Assert
            Assert.IsInstanceOf<Rental>(rental);
            Assert.NotNull(rental);
        }

        [Test]
        public void AddCar_ShouldAddCarToRental()
        {
            // Arrange
            Car newCar = new Car();
            Rental rental = new Rental(title, address);

            // Act
            rental.AddCar(newCar);

            Assert.AreEqual(1, rental.Cars.Count);
        }

        [Test]
        public void AddEmployee_ShouldAddEmployeeToRental()
        {
            // Arrange
            Employee emp = new Employee();
            Rental rental = new Rental(title, address);

            // Act
            rental.AddEmployee(emp);

            Assert.AreEqual(1, rental.Employees.Count);
        }
    }
}