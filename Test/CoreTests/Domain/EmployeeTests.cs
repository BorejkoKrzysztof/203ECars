using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;

namespace Test.CoreTests.Domain
{
    public class EmployeeTests
    {
        private Account account;
        private Address address;
        private Person person;
        private Department department;
        private BuisnessPosition position;
        private Rental rental;

        [SetUp]
        public void Setup()
        {
            this.account = new Account("TestEmail@gmail.com", "bsdkbvddbadjabdbda");
            this.address = new Address("street", "444", "city", "1212-121-22");
            this.person = new Person("FirstName", "SurName", "123456789");
            this.department = Department.Sales;
            this.position = BuisnessPosition.Director;
            this.rental = new Rental();
        }

        [Test]
        public void CreateEmployee_IncorrectData_PersonIsNull_ShouldThrowNewArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Employee employee1 = new Employee(null!, address, account, department, position, rental);
            });
        }

        [Test]
        public void CreateEmployee_IncorrectData_AddressIsNull_ShouldThrowNewArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Employee employee1 = new Employee(person, null!, account, department, position, rental);
            });
        }

        [Test]
        public void CreateEmployee_IncorrectData_AccountIsNull_ShouldThrowNewArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Employee employee1 = new Employee(person, address, null!, department, position, rental);
            });
        }

        [Test]
        public void CreateEmployee_IncorrectData_RentalIsNull_ShouldThrowNewArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Employee employee1 = new Employee(person, address, account, department, position, null!);
            });
        }

        [Test]
        public void CreateEmployee_CorrectData_ShouldCreateNewInstanceOfEmployee()
        {
            // Act
            Employee newEmployee = new Employee(person, address, account, department, position, rental);

            // Assert
            Assert.IsInstanceOf<Employee>(newEmployee);
            Assert.NotNull(newEmployee);
        }
    }
}