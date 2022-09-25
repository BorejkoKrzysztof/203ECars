using _2035Cars_Core.ValueObjects;

namespace Test.CoreTests.ValueObjects
{
    public class CarEquipmentTests
    {
        [Test]
        public void CreateCarEquipment_CorrectData_ShouldCreateNewInstanceOfCarEquipment()
        {
            // Act
            CarEquipment carEquipment = new CarEquipment(true, true, true, true);

            // Assert
            Assert.IsInstanceOf<CarEquipment>(carEquipment);
            Assert.NotNull(carEquipment);
        }
    }
}