using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Test.InfrastructureTests.CarRepository
{
    public class CarRepositoryTests
    {
        private readonly CarDbContext dbContext;
        private readonly _2035Cars_Infrastructure.Repositories.CarRepository repository;
        private List<Car> collectionOfCars;

        public CarRepositoryTests()
        {
            DbContextOptionsBuilder dbOptions = new DbContextOptionsBuilder()
                                                .UseInMemoryDatabase(Guid.NewGuid().ToString());  

            this.dbContext = new CarDbContext(dbOptions.Options);
            this.repository = new _2035Cars_Infrastructure.Repositories.CarRepository(this.dbContext);
        }


        [SetUp]
        public void Setup()
        {
            var mainRental = new Rental(
                        "Lotnisko",
                        new _2035Cars_Core.ValueObjects.Address(
                            "street1",
                            "23a",
                            "Warszawa",
                            "55-122"
                        )
                    );
            
            this.collectionOfCars = new List<Car>()
            {
                new Car(
                    "BMW",
                    "M4",
                    _2035Cars_Core.Enums.CarType.Sport,
                    new _2035Cars_Core.ValueObjects.CarEquipment(true, true, true, true),
                    _2035Cars_Core.Enums.DriveOfCar.Hybrid,
                    2,
                    4,
                    250.00M,
                    new byte[2],
                    mainRental
                ),
                new Car(
                    "Audi",
                    "A4",
                    _2035Cars_Core.Enums.CarType.Sedan,
                    new _2035Cars_Core.ValueObjects.CarEquipment(true, false, true, true),
                    _2035Cars_Core.Enums.DriveOfCar.Hybrid,
                    4,
                    4,
                    150.00M,
                    new byte[2],
                    new Rental(
                        "Rynek",
                        new _2035Cars_Core.ValueObjects.Address(
                            "street2",
                            "23a",
                            "Poznań",
                            "55-123"
                        )
                    )
                ),
                new Car(
                    "Mercedes",
                    "E",
                    _2035Cars_Core.Enums.CarType.Convertible,
                    new _2035Cars_Core.ValueObjects.CarEquipment(false, false, false, true),
                    _2035Cars_Core.Enums.DriveOfCar.Hybrid,
                    2,
                    4,
                    150.00M,
                    new byte[2],
                    new Rental(
                        "Śródmieście",
                        new _2035Cars_Core.ValueObjects.Address(
                            "street3",
                            "23a",
                            "Gdańsk",
                            "55-124"
                        )
                    )
                ),
                new Car(
                    "Tesla",
                    "3",
                    _2035Cars_Core.Enums.CarType.Sedan,
                    new _2035Cars_Core.ValueObjects.CarEquipment(false, false, true, true),
                    _2035Cars_Core.Enums.DriveOfCar.Electric,
                    4,
                    4,
                    450.00M,
                    new byte[2],
                    mainRental
                )
            };
        }

        [Test]
        public void GetAllNotRentedCarsByRentalLoactionAsync_NoDataInDatabase_ShouldThrowInvalidOperationException()
        {
            // Arrange
            string city = "Warszawa";
            string rentalTitle = "Lotnisko im.Fryderyka Chopina";

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => {
                var id = await this.repository.GetAllNotRentedCarsByRentalLoactionAsync(city, rentalTitle);
            });
        }

        [Test]
        public async Task GetAllNotRentedCarsByRentalLoactionAsync_CorrectData_ShouldReturnCollectionOfNotRentedCars()
        {
            // Arrange
            var copyOfCarsCollection = this.collectionOfCars;
            copyOfCarsCollection[0].RentCar();

            string city = "Warszawa";
            string rentalLocation = "Lotnisko";

            await this.dbContext.Cars.AddRangeAsync(copyOfCarsCollection);
            await this.dbContext.SaveChangesAsync();

            // Act
            var collectionFromDB = await this.repository.GetAllNotRentedCarsByRentalLoactionAsync(city, rentalLocation);

            // Assert
            Assert.IsInstanceOf<List<Car>>(collectionFromDB);
            Assert.That(collectionFromDB.Count, Is.EqualTo(1));
            Assert.That(collectionFromDB[0].Brand, Is.EqualTo("Tesla"));
        }

        [Test]
        public async Task GetAllCarsByCarTypeAsync_NoCarsInDatabase_ShouldReturnNull()
        {
            // Arrange
            CarType preferableCarType = CarType.Sedan;

            // Act
            var collectionOfCarsByType = await this.repository.GetAllCarsByCarTypeAsync(preferableCarType);

            // Assert
            Assert.IsInstanceOf<List<Car>>(collectionOfCarsByType);
            Assert.That(collectionOfCarsByType.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetAllCarsByCarTypeAsync_CorrectData_ShouldReturnCollectionOfCarsWithSpecificBody()
        {
            // Arrange
            var copyOfCarsCollection = this.collectionOfCars;

            await this.dbContext.Cars.AddRangeAsync(copyOfCarsCollection);
            await this.dbContext.SaveChangesAsync();

            CarType preferableCarType = CarType.Sedan;

            // Act
            var collectionOfCarsByType = await this.repository.GetAllCarsByCarTypeAsync(preferableCarType);

            // Assert
            Assert.IsInstanceOf<List<Car>>(collectionOfCarsByType);
            Assert.That(collectionOfCarsByType.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAllSelectedCarsAsync_NoDataInDatabase_ShouldThrowInvalidOperationException()
        {
            // Arrange
            string city = "Warszawa";
            string rentalTitle = "Lotnisko im.Fryderyka Chopina";

            CarEquipment desiredEquipment = new CarEquipment(true, false, true, false);

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => {
                var id = await this.repository.GetAllSelectedCarsAsync(city, rentalTitle, desiredEquipment);
            });
        }


        // TU JEST BLAD Z MOIM COMPAREREM   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
        [Test]
        public async Task GetAllSelectedCarsAsync_CorrectData_ShouldReturnCollectionWithSpecificOptions()
        {
            // Arrange
            string city = "Warszawa";
            string rentalTitle = "Lotnisko im.Fryderyka Chopina";

            CarEquipment desiredEquipment = new CarEquipment(false, false, false, true);

            await this.dbContext.Cars.AddRangeAsync(this.collectionOfCars);
            await this.dbContext.SaveChangesAsync();

            // Act
            var collectionFromDB = await this.repository
                            .GetAllSelectedCarsAsync(city, rentalTitle, desiredEquipment);

            // Assert
            Assert.IsInstanceOf<List<Car>>(collectionFromDB);
            Assert.That(collectionFromDB.Count, Is.EqualTo(2));
        }


        [TearDown]
        public void CleanContext()
        {
            this.dbContext.ChangeTracker.Clear();
            this.dbContext.Database.EnsureDeleted();
        }
    }
}