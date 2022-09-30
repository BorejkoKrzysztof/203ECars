using _2035Cars_Application.Interfaces;
using _2035Cars_Application.Mapping;
using AutoMapper;
using Moq;

namespace Test.ApplicationTests.RentalService
{
    public class RentalServiceTests
    {
        private readonly Mock<IRentalService> mockToDoItemRepository;
        private readonly IMapper mapper;

        public RentalServiceTests()
        {
            this.mockToDoItemRepository = new Mock<IRentalService>();
            this.mapper = RentalProfile.Initialize();
        }

        [SetUp]
        public void SetUp()
        {
            
        }
    }
}