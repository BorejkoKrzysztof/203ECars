using _2035Cars_Application.Interfaces;
using _2035Cars_Application.Mapping;
using _2035Cars_Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test.ApplicationTests.RentalService
{
    public class RentalServiceTests
    {
        private  Mock<IRentalRepository> mockRentalRepository;
        private  IMapper mapper;
        private  ILogger<_2035Cars_Application.Services.RentalService> logger;
        private  _2035Cars_Application.Services.RentalService rentalService;

        [SetUp]
        public void SetUp()
        {
            this.mockRentalRepository = new Mock<IRentalRepository>();
            this.mapper = RentalProfile.Initialize();
            this.logger = LoggerFactory.Create(options => {})
                                .CreateLogger<_2035Cars_Application.Services.RentalService>();

            this.rentalService = new _2035Cars_Application.Services.RentalService(
                                this.mockRentalRepository.Object, this.logger, this.mapper);
        }

        [Test]
        public async Task GetRentalCitiesAsync_NoCitiesInDb_ShouldReturnEmptyCollection()
        {
            // Arrange
            List<string> returnedCities = new List<string>();

            this.mockRentalRepository.Setup(x => x.ReadAllRentalCitiesAsync())
                                        .Returns(Task.FromResult(returnedCities));

            // Act
            var citiesFromService = await this.rentalService.GetRentalCitiesAsync();

            // Assert
            Assert.IsInstanceOf<List<string>>(citiesFromService);
            Assert.That(citiesFromService.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetRentalCitiesAsync_NoCitiesInDb_ShouldReturnCollectionWithNamesOfCities()
        {
            // Arrange
            List<string> returnedCities = new List<string>(){
                "Warszawa",
                "Poznań",
                "Kraków",
                "Gdańsk"
            };

            this.mockRentalRepository.Setup(x => x.ReadAllRentalCitiesAsync())
                                        .Returns(Task.FromResult(returnedCities));

            // Act
            var citiesFromService = await this.rentalService.GetRentalCitiesAsync();

            // Assert
            Assert.IsInstanceOf<List<string>>(citiesFromService);
            Assert.That(citiesFromService.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetRentalLocationsAsync_IncorrectData_GivenCityIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            string city = null!;

            // Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => {
                var rentalLocations = await this.rentalService.GetRentalLocationsAsync(city);
            });
        }

        [Test]
        public async Task GetRentalLocationsAsync_CorrectData_NoLocationsForGivenCity_ShouldReturnEmptyCollection()
        {
            // Arrange
            string givenCity = "Warszawa";
            var emptyCollection = new List<string>();
            this.mockRentalRepository.Setup(x => x.ReadAllLocationsByCityAsync(givenCity))
                                        .ReturnsAsync(emptyCollection);

            // Act
            var locationsFromService = await this.rentalService.GetRentalLocationsAsync(givenCity);

            // Assert
            Assert.IsInstanceOf<List<string>>(locationsFromService);
            Assert.That(locationsFromService.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetRentalLocationsAsync_CorrectData__ShouldReturnCollectionWithRentalTitles()
        {
            // Arrange
            string givenCity = "Warszawa";
            var fakeCollectionResult = new List<string>()
            {
                "Lotnisko",
                "Śródmieście",
                "Poznań-Ławica"
            };

            this.mockRentalRepository.Setup(x => x.ReadAllLocationsByCityAsync(givenCity))
                                        .ReturnsAsync(fakeCollectionResult);

            // Act
            var locationsFromService = await this.rentalService.GetRentalLocationsAsync(givenCity);

            // Assert
            Assert.IsInstanceOf<List<string>>(locationsFromService);
            Assert.That(locationsFromService.Count, Is.EqualTo(3));
        }

    }
}