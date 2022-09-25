using _2035Cars_Core.Domain;

namespace Test.CoreTests.Domain
{
    public class OrderTests
    {
        private long publishEmployeeId;
        private long acceptEmployeeId;
        private long clientId;
        private long carId;
        private long fromRentalId;
        private long toRentalId;
        private DateTime startDate;
        private DateTime endDate;
        private decimal costOfRental;

        [SetUp]
        public void Setup()
        {
            this.publishEmployeeId = 767665L;
            this.acceptEmployeeId = 87587585L;
            this.clientId = 6877875L;
            this.carId = 969875875L;
            this.fromRentalId = 7734856874L;
            this.toRentalId = 678987875L;
            this.startDate = DateTime.UtcNow;
            this.endDate = DateTime.UtcNow.AddDays(3);
            this.costOfRental = 356.00M;
        }

        [Test]
        public void CreateOrder_CorrectData_ShouldCreateNewOrder()
        {
            // Act
            Order newOrder = new Order(publishEmployeeId, clientId, carId, fromRentalId, 
                                            toRentalId, startDate, endDate, costOfRental);

            // Assert
            Assert.IsInstanceOf<Order>(newOrder);
            Assert.NotNull(newOrder);
        }

        [Test]
        public void FinishOrder_ShouldFinishOrder()
        {
            // Arrange
            Order newOrder = new Order(publishEmployeeId, clientId, carId, fromRentalId, 
                                            toRentalId, startDate, endDate, costOfRental);

            // Act
            newOrder.FinishOrder(54265372575L);

            // Assert
            Assert.Equals(true, newOrder.Finished);
        }
    }
}