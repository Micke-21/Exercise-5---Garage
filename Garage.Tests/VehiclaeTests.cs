using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise_5___Garage.Vehicles;

namespace Garage.Tests
{
    [TestClass]
    public class VehiclaeTests
    {
        [TestMethod]
        public void Vehicle_RegNoConvertedtoUppercase_RegNoUppercase()
        {
            //Arrange
            var input = "abc123";
            var expected = "ABC123";
            var vehicle = new Vehicle { RegNo = input };

            //Act
            var actual = vehicle.RegNo;

            //Assert
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(expected, actual);

        }
    }
}