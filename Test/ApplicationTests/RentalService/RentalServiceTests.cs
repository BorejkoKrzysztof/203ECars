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
        private readonly Mock<IRentalRepository> mockRentalRepository;
        private readonly IMapper mapper;
        private readonly ILogger<_2035Cars_Application.Services.RentalService> logger;
        private readonly _2035Cars_Application.Services.RentalService rentalService;

        public RentalServiceTests()
        {
            this.mockRentalRepository = new Mock<IRentalRepository>();
            this.mapper = RentalProfile.Initialize();
            this.logger = LoggerFactory.Create(options => {})
                                .CreateLogger<_2035Cars_Application.Services.RentalService>();

            this.rentalService = new _2035Cars_Application.Services.RentalService(
                                this.mockRentalRepository.Object, this.logger, this.mapper);
        }

        [SetUp]
        public void SetUp()
        {
            
        }

        // Task<List<string>> GetRentalCitiesAsync();
        // Task<List<string>> GetRentalLocationsAsync(string city);


    }
}