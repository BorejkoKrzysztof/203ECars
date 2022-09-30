using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Test.InfrastructureTests.RentalRepository
{
    public class RentalRepositoryTests
    {
        private readonly CarDbContext dbContext;
        private readonly _2035Cars_Infrastructure.Repositories.RentalRepository repository;
        private List<Rental> collectionOfRentals;

        public RentalRepositoryTests()
        {
            DbContextOptionsBuilder dbOptions = new DbContextOptionsBuilder()
                                                .UseInMemoryDatabase(Guid.NewGuid().ToString());  

            this.dbContext = new CarDbContext(dbOptions.Options);
            this.repository = new _2035Cars_Infrastructure.Repositories.RentalRepository(this.dbContext);    
        }


        [SetUp]
        public void Setup()
        {
            this.collectionOfRentals = new List<Rental>()
            {
                new Rental(
                    "Lotnisko",
                    new _2035Cars_Core.ValueObjects.Address(
                        "Street1",
                        "21a",
                        "Warszawa",
                        "21-232"
                    )
                ),
                new Rental(
                    "Rynek",
                    new _2035Cars_Core.ValueObjects.Address(
                        "Street2",
                        "2222a",
                        "Warszawa",
                        "21-232"
                    )
                ),
                new Rental(
                    "Śródmieście",
                    new _2035Cars_Core.ValueObjects.Address(
                        "Street1",
                        "21a",
                        "Poznań",
                        "21-2321"
                    )
                )
            };
        }


        [Test]
        public async Task ReadAllRentalCitiesAsync_NoDataInDb_ShouldReturnEmptyCollection()
        {
            // Act
            var cities = await this.repository.ReadAllRentalCitiesAsync();

            // Assert
            Assert.IsInstanceOf<List<string>>(cities);
            Assert.That(cities.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task ReadAllRentalCitiesAsync_ShouldReturnCollectionOfCities_WithoutDuplicates()
        {
            // Arrange
            await this.dbContext.Rentals.AddRangeAsync(this.collectionOfRentals);
            await this.dbContext.SaveChangesAsync();

            // Act
            var cities = await this.repository.ReadAllRentalCitiesAsync();

            // Assert
            Assert.IsInstanceOf<List<string>>(cities);
            Assert.That(cities.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task ReadAllLocationsByCityAsync_NoDataInDb_ShouldReturnEmptyCollection()
        {
            // Arrange
            string city = "Warszawa";

            // Act
            var rentalLocations = await this.repository.ReadAllLocationsByCityAsync(city);  

            // Assert
            Assert.IsInstanceOf<List<string>>(rentalLocations);
            Assert.That(rentalLocations.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task ReadAllLocationsByCityAsync_CorrectData_ShouldReturnCollectionOfLocations()
        {
            // Arrange
            await this.dbContext.Rentals.AddRangeAsync(this.collectionOfRentals);
            await this.dbContext.SaveChangesAsync();
            
            string city = "Warszawa";

            // Act
            var rentalLocations = await this.repository.ReadAllLocationsByCityAsync(city);  

            // Assert
            Assert.IsInstanceOf<List<string>>(rentalLocations);
            Assert.That(rentalLocations.Count, Is.EqualTo(2));
        }

        [TearDown]
        public void CleanContext()
        {
            this.dbContext.ChangeTracker.Clear();
            this.dbContext.Database.EnsureDeleted();
        }
    }
}