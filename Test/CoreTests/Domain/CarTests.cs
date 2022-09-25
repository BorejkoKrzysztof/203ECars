using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;

namespace Test.CoreTests.Domain
{
    public class CarTests
    {
        private string brand;
        private string model;
        private CarType carType;
        private CarEquipment carEquipment;
        private DriveOfCar driveOfCar;
        private int amountOfDoor;
        private int amountOfSeats;
        private decimal priceForOneHour;
        private byte[] carImage;
        private Rental rental;

        [SetUp]
        public void SetUp()
        {
            this.brand = "BMW";
            this.model = "5";
            this.carType = CarType.Sedan;
            this.carEquipment = new CarEquipment(true, true, true, true);
            this.driveOfCar = DriveOfCar.Hybrid;
            this.amountOfDoor = 4;
            this.amountOfSeats = 5;
            this.priceForOneHour = 350.00M;
            this.carImage = new byte[2];
            this.rental = new Rental();
        }


        [Test]
        public void CreateCarInstance_IncorrectData_BrandIsNullOrEmpty_ShouldThrowArgumentNullExcenption()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Car car1 = new Car("", model, carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, rental);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Car car1 = new Car("", model, carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, rental);
            });
        }

        [Test]
        public void CreateCarInstance_IncorrectData_ModelIsNullOrEmpty_ShouldThrowArgumentNullExcenption()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Car car1 = new Car(brand, "", carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, rental);
            });

            Assert.Throws<ArgumentNullException>(() => {
                Car car1 = new Car(brand, null!, carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, rental);
            });
        }

        [Test]
        public void CreateCarInstance_IncorrectData_EquipmentIsNull_ShouldThrowArgumentNullExcenption()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Car car1 = new Car(brand, model, carType, null!, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, rental);
            });
        }

        [Test]
        public void CreateCarInstance_IncorrectData_ImageIsNull_ShouldThrowArgumentNullExcenption()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Car car1 = new Car(brand, model, carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, null!, rental);
            });
        }

        [Test]
        public void CreateCarInstance_IncorrectData_RentalIsNull_ShouldThrowArgumentNullExcenption()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => {
                Car car1 = new Car(brand, model, carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, null!);
            });
        }

        [Test]
        public void CreateCarInstance_CorrectData_ShouldCreateNewInstanceOfCar()
        {
           // Act
           Car newCar = new Car(brand, model, carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, rental);

            // Assert
            Assert.IsInstanceOf<Car>(newCar);
            Assert.NotNull(newCar);
        }

        [Test]
        public void RentCar_ShouldModifyIsRentedProperty()
        {
            // Arrange
            Car newCar = new Car(brand, model, carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, rental);

            // Act
            newCar.RentCar();

            // Assert
            Assert.AreEqual(true, newCar.IsRented);
        }

        [Test]
        public void FinishRental_ShouldModifyIsRentedProperty()
        {
            // Arrange
            Car newCar = new Car(brand, model, carType, carEquipment, 
                                    driveOfCar, amountOfDoor, amountOfSeats, 
                                    priceForOneHour, carImage, rental);
            newCar.RentCar();

            // Act
            newCar.FinishRental();

            // Assert
            Assert.AreEqual(false, newCar.IsRented);
        }
    }
}