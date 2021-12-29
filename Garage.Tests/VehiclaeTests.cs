using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise_5___Garage.Vehicles;
using System;

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
            var vehicle = new Vehicle(input) /*{ RegNo = input }*/;

            //Act
            var actual = vehicle.RegNo;

            //Assert
            Assert.IsNotNull(vehicle);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Vehicle_NoRegNo_throws()
        {
            //Arrange
            var input = "";
            var expected = "";
            var vehicle = new Vehicle(input) /*{ RegNo = input }*/;

            //Act
            var actual = vehicle.RegNo;

            //Assert
            Assert.IsNull(vehicle);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Vehicle_NullRegNo_Throw()
        {
            //Arrange
            string? input = null;
            //var expected = "";
            var vehicle = new Vehicle(input!) /*{ RegNo = input! }*/;

            //Act
            _ = vehicle.RegNo;

            //Assert
            //Assert.IsNotNull(vehicle);
            //Assert.AreEqual(expected, actual);

        }
    }
}