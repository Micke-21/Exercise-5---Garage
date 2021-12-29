using Exercise_5___Garage;
using Exercise_5___Garage.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Garage.Tests
{
    [TestClass]
    public class GarageTests
    {
        #region IsRegNoFound tests
        [TestMethod]
        [TestCategory("TestCategori")]
        [TestCategory("Mock")]
        public void IsRegNoFound_()
        {
            //Arrange
            //var mGarage = new Mock<IGarage<Vehicle>>();
            var regNo = "ABC123";

            //mGarage.Setup(m => m.GetAllVehicle()).Returns(new Vehicle[] = null);
            var g = new Garage<Vehicle>(9);
            g.SeedVehicles();

            //Act
            //var result = mGarage.IsRegNoFound(regNo);
            var result = g.IsRegNoFound(regNo);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        [TestCategory("TestCategori")]
        public void IsRegNoFound_RegNoFound_()
        {
            //Arrange         
            var regNo = "ABC123";
            var garage = new Garage<Vehicle>(9);
            garage.SeedVehicles();

            //Act
            var result = garage.IsRegNoFound(regNo);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRegNoFound_RegNoNotFound_()
        {
            //ToDo TEST Fix Moq
            //Arrange
            var regNo = "NotFound";
            var g = new Garage<Vehicle>(9);
            g.SeedVehicles();

            //Act
            var result = g.IsRegNoFound(regNo);

            //Assert
            Assert.IsFalse(result);

        }
        #endregion IsRegNoFound tests

        #region RemoveVehicle tests

        [TestMethod]
        public void RemoveVeicle_VehicleRemoved()
        {
            //Arrage
            var garage = new Garage<Vehicle>(9);
            garage.SeedVehicles();

            var regnoToRemove = "ABC123";
            var freePlaceceBefore = garage.FreePlaces;

            //Act
            var result = garage.RemoveVehicle(regnoToRemove);
            var freePlaceceAfter = garage.FreePlaces;

            //Assert
            Assert.IsTrue(result); 
            Assert.AreEqual(freePlaceceBefore+1, freePlaceceAfter);

        }

        [TestMethod]
        public void RemoveVeicle_VehicleNotFoundRemoved()
        {
            //Arrage
            var garage = new Garage<Vehicle>(9);
            garage.SeedVehicles();

            var regnoToRemove = "NotFounRegNo";
            var freePlaceceBefore = garage.FreePlaces;

            //Act
            var result = garage.RemoveVehicle(regnoToRemove);
            var freePlaceceAfter = garage.FreePlaces;

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(freePlaceceBefore, freePlaceceAfter);

        }

        [TestMethod]
        public void RemoveVeicle_NoRegNoEntered_()
        {
            //Arrage
            var garage = new Garage<Vehicle>(9);
            garage.SeedVehicles();

            var regnoToRemove = "";
            var freePlaceceBefore = garage.FreePlaces;

            //Act
            var result = garage.RemoveVehicle(regnoToRemove);
            var freePlaceceAfter = garage.FreePlaces;

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(freePlaceceBefore, freePlaceceAfter);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveVeicle_NullRegNoEntered_()
        {
            //Arrage
            var garage = new Garage<Vehicle>(9);
            garage.SeedVehicles();

            string? regnoToRemove = null;
            //var freePlaceceBefore = garage.FreePlaces;

            //Act
            _ = garage.RemoveVehicle(regnoToRemove!);
            //var freePlaceceAfter = garage.FreePlaces;

            //Assert
            //Assert.IsFalse(result);
            //Assert.AreEqual(freePlaceceBefore, freePlaceceAfter);

        }
        #endregion RemoveVehicle tests

        #region AddVehicle tests

        [TestMethod]
        public void AddVehicle_VehicleAdded_True()
        {
            //Arrage
            var garage = new Garage<Vehicle>(9);
            garage.SeedVehicles();

            var newVehicle = new Airplane("SE-IRD") { Color = "White/Blue", 
                Make = "Cessna", 
                Model = "Skyhawk II", 
                NoOfWheel = 3, 
                NumberOfEngines = 1, 
                //RegNo = "SE-IRD", 
                WingSpan = 10.92M };
            var freePlaceceBefore = garage.FreePlaces;

            //Act
            var result = garage.AddVehicle(newVehicle);
            var freePlaceceAfter = garage.FreePlaces;

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(freePlaceceBefore-1, freePlaceceAfter);
        }

        [TestMethod]
        public void AddVehicle_VehicleAlreadyAdded_Fasle()
        {
            //Arrage
            var garage = new Garage<Vehicle>(9);
            garage.SeedVehicles();

            var newVehicle = new Airplane("SE-VPU")
            {
                Color = "White/Blue",
                Make = "Cessna",
                Model = "Skyhawk II",
                NoOfWheel = 3,
                NumberOfEngines = 1,
                //RegNo = "SE-VPU",
                WingSpan = 10.92M
            };
            var freePlaceceBefore = garage.FreePlaces;

            //Act
            var result = garage.AddVehicle(newVehicle);
            var freePlaceceAfter = garage.FreePlaces;

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(freePlaceceBefore, freePlaceceAfter);
        }
        #endregion AddVehicle tests
    }
}
