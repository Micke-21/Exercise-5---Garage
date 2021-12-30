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
            var g = new Garage2<Vehicle>(9);
            //g.SeedVehicles();
            g.AddVehicle(new Car(regNo));

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
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Car(regNo));

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
            var g = new Garage2<Vehicle>(9);
            //g.SeedVehicles();
            g.AddVehicle(new Car("ABC123"));

            //Act
            var result = g.IsRegNoFound(regNo);

            //Assert
            Assert.IsFalse(result);

        }
        #endregion IsRegNoFound tests

        #region RemoveVehicle tests

        [TestMethod]
        public void RemoveVeicle_ByRegNo_VehicleRemoved()
        {
            //Arrage
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Car("ABC123"));

            var regnoToRemove = "ABC123";
            var freePlaceceBefore = garage.FreePlaces;

            //Act
            var result = garage.RemoveVehicle(regnoToRemove);
            var freePlaceceAfter = garage.FreePlaces;

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(freePlaceceBefore + 1, freePlaceceAfter);

        }

        [TestMethod]
        public void RemoveVeicle_ByVehicle_VehicleRemoved()
        {
            //Arrage
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Car("ABC456"));
            garage.AddVehicle(new Car("ABC123"));

            var regnoToRemove = "ABC123";
            var freePlaceceBefore = garage.FreePlaces;
            var vehicleToRemove = garage.GetVehicleByRegNo(regnoToRemove);

            //Act
            var result = garage.RemoveVehicle(vehicleToRemove);
            var freePlaceceAfter = garage.FreePlaces;

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(freePlaceceBefore + 1, freePlaceceAfter);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveVeicle_ByVehicle_NoVehicleFound_VehicleRemoved_Throws()
        {
            //Arrage
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Car("ABC456"));
            garage.AddVehicle(new Car("ABC123"));

            var regnoToRemove = "REGNONOTFOUND";
            
            var vehicleToRemove = garage.GetVehicleByRegNo(regnoToRemove);

            //Act
            _ = garage.RemoveVehicle(vehicleToRemove!);


            //Assert


        }

        [TestMethod]
        public void RemoveVeicle_VehicleNotFoundRemoved()
        {
            //Arrage
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Car("ABC123"));

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
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Car("ABC123"));

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
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Car("ABC123"));

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
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            _ = garage.AddVehicle(new Car("ABC123"));

            var newVehicle = new Airplane("SE-IRD")
            {
                Color = "White/Blue",
                Make = "Cessna",
                Model = "Skyhawk II",
                NoOfWheel = 3,
                NumberOfEngines = 1,
                //RegNo = "SE-IRD", 
                WingSpan = 10.92M
            };
            var freePlaceceBefore = garage.FreePlaces;

            //Act
            var result = garage.AddVehicle(newVehicle);
            var freePlaceceAfter = garage.FreePlaces;

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(freePlaceceBefore - 1, freePlaceceAfter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddVehicle_VehicleAlreadyAdded_Fasle()
        {
            //Arrage
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Airplane("SE-VPU"));

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
        #region Garage2 tests
        [TestMethod]
        [TestCategory("TestCategori")]
        public void _IsRegNoFound_RegNoFound_Garage2()
        {
            //Arrange         
            var regNo = "ABC1";
            var garage = new Garage2<Vehicle>(9);
            //garage.SeedVehicles();
            garage.AddVehicle(new Car("ABC1") { Color = "Yellow" });
            garage.AddVehicle(new Car("ABC2") { Color = "Yellow" });
            garage.AddVehicle(new Car("ABC3") { Color = "Yellow" });

            foreach (var vehicle in garage)
            {
                Assert.AreEqual("Yellow", vehicle.Color);
            }
            //Act
            var result = garage.IsRegNoFound(regNo);

            //Assert
            Assert.IsTrue(result);
        }
        #endregion Garage2 tests
    }
}
