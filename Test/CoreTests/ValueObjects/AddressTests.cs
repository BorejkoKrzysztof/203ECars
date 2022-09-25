using _2035Cars_Core.ValueObjects;

namespace Test.CoreTests.ValueObjects
{
    public class AddressTests
    {
        private string street;
        private string number;
        private string city;
        private string zipCode;

        [SetUp]
        public void SetUp()
        {
            this.street = "street";
            this.number = "55";
            this.city = "Warsaw";
            this.zipCode ="555-222";
        }

        [Test]
        public void CreateAddress_IncorrectData_StreetIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Address account = new Address(string.Empty, number, city, zipCode);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Address account = new Address(null!, number, city, zipCode);
            });
        }

        [Test]
        public void CreateAddress_IncorrectData_NumberIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Address account = new Address(street, string.Empty, city, zipCode);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Address account = new Address(street, null!, city, zipCode);
            });
        }

        [Test]
        public void CreateAddress_IncorrectData_CityIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Address account = new Address(street, number, string.Empty, zipCode);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Address account = new Address(street, number, null!, zipCode);
            });
        }

        [Test]
        public void CreateAddress_IncorrectData_ZipCodeIsNullOrEmpty_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Address account = new Address(street, number, city, string.Empty);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Address account = new Address(street, number, city, null!);
            });
        }

        [Test]
        public void CreateAddress_CorrectData_ShouldCreateNewInstanceOfAddress()
        {
            // Act
            Address address = new Address(street, number, city, zipCode);

            // Assert
            Assert.IsInstanceOf<Address>(address);
            Assert.NotNull(address);
        }

        
    }
}