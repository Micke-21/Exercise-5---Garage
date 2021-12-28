using Exercise_5___Garage;
using Exercise_5___Garage.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Tests
{
    [TestClass]
    public class GarageHandlerTests
    {
        [TestMethod]
        public void IsGarageFull_GrageNOTFull_true()
        {
            //Arrange
            var gh = new GarageHandler();
            //Mock<IGarage<Vehicle>> mg = new Mock<IGarage<Vehicle>>();
            //mg.Setup(g => g.IsFull).Returns(true);

            Mock<IUI> ui = new Mock<IUI>();
            ui.Setup(x => x.GetStringInput(It.IsAny<string>())).Returns("2");
            //1. Vehicle
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Enter Reg no: ")))).Returns("ASD789");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Make:")))).Returns("Volvo");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Model:")))).Returns("V70");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Color:")))).Returns("Vit");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("whells:")))).Returns("4");
            //ToDo går det att få olika värden beroende på vilket anrop det är? Ja


            gh.CreatGarage();
            gh.AddVehicle();
            gh.AddVehicle(ui.Object, "1");

            //Act
            var result = gh.IsGarageFull();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsGarageFull_GarageFULL_false()
        {
            //Arrange
            var gh = new GarageHandler();
            //Mock<IGarage<Vehicle>> mg = new Mock<IGarage<Vehicle>>();

            //mg.Setup(g => g.IsFull).Returns(false);
            //mg.Setup(g => g.GetVehicleByRegNo("")).Returns(new Car { Color = "Blue", RegNo = "QWE" });
            gh.CreatGarage();

            //Act
            //var result = gh.GetVehicle("abs");
            var result = gh.IsGarageFull();

            //Assert
            Assert.IsFalse(result);

        }

        /// <summary>
        /// Alldeles för stor test mest för att testa lite olika grejer
        /// </summary>
        /// <param name="val"></param>
        /// <exception cref="ArgumentNullException"></exception>
        [TestMethod]
        [DataRow("1")]
        [DataRow("2")]
        [DataRow("3")]
        [DataRow("4")]
        [DataRow("5")]
        [DataRow("6")]
        public void AddVehicle_DifferentTypesOfVehicle_true(string val)
        {
            if (val is null)
            {
                throw new ArgumentNullException(nameof(val));
            }

            //Arrange
            var gh = new GarageHandler();

            Mock<IUI> ui = new Mock<IUI>();
            ui.Setup(x => x.GetStringInput(It.IsAny<string>())).Returns("2");
            //1. Vehicle
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Enter Reg no: ")))).Returns("ASD789");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Make:")))).Returns("Volvo");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Model:")))).Returns("V70");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Color:")))).Returns("Vit");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("whells:")))).Returns("4");
            //2. Airplane
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Enter WingSpan: ")))).Returns("10,92");
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("No of Engines: ")))).Returns("1");
            //3. Boat
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Lenght:")))).Returns("32");
            //4. Bus 
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("Seats:")))).Returns("45");
            //5. Car
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("FuelType:")))).Returns("E85");
            //6. Mororcycle
            ui.Setup(x => x.GetStringInput(It.Is<string>(s => s.Contains("CylinderVolume:")))).Returns("750");

            //ToDo går det att få olika värden beroende på vilket anrop det är? Ja!


            gh.CreatGarage();
            gh.AddVehicle();
            gh.AddVehicle(ui.Object, val);

            //Act
            var result = gh.GetVehicle("ASD789");
           
            //Assert
            Assert.AreEqual("ASD789", result.RegNo);
            Assert.AreEqual("Volvo", result.Make);
            Assert.AreEqual("V70", result.Model);
            Assert.AreEqual("Vit", result.Color);
            Assert.AreEqual(4, result.NoOfWheel);

            switch (val)
            {
                case "2":
                    var v = result as Airplane;
                    Assert.AreEqual(10.92M, v.WingSpan);
                    Assert.AreEqual(1, v.NumberOfEngines);
                    break;
                case "3":
                    var boat = result as Boat;
                    Assert.AreEqual(32, boat.Lenght);
                    break;
                case "4":
                    var bus = result as Bus;
                    Assert.AreEqual(45, bus.NumberOfSeats);
                    break;
                case "5":
                    var car = result as Car;
                    Assert.AreEqual("E85", car.Fueltype);
                    break;
                case "6":
                    var mc = result as Motorcycle;
                    Assert.AreEqual(750, mc.CylinderVolume);
                    break;
                default:
                    break;
            }
        }


        #region GetVehicle Tests

        [TestMethod]
        public void GetVehicle_VehicleFound()
        {
            //Arrange
            var gh = new GarageHandler();
            gh.CreatGarage();
            var regNoToFind = "ABC123";

            //Act
            var result = gh.GetVehicle(regNoToFind);

            //Assert
            Assert.AreEqual(regNoToFind, result.RegNo);
        }

        [TestMethod]
        public void GetVehicle_VehicleNOTFound()
        {
            //Arrange
            var gh = new GarageHandler();
            gh.CreatGarage();
            var regNoToFind = "NotFoundRegNo";

            //Act
            var result = gh.GetVehicle(regNoToFind);

            //Assert
            Assert.IsNull(result);
            //Assert.AreEqual(regNoToFind, result.RegNo);
        }

        [TestMethod]
        public void GetVehicle_VehicleNORegNo()
        {
            //Arrange
            var gh = new GarageHandler();
            gh.CreatGarage();
            var regNoToFind = "";

            //Act
            var result = gh.GetVehicle(regNoToFind);

            //Assert
            Assert.IsNull(result);
            //Assert.AreEqual(regNoToFind, result.RegNo);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetVehicle_VehicleNullRegNo_throws()
        {
            //Arrange
            var gh = new GarageHandler();
            gh.CreatGarage();
            string? regNoToFind = null;

            //Act
            _ = gh.GetVehicle(regNoToFind!);

            //Assert

            //TODO Take care of Null reference Exception
        }

        #endregion GetVehicle Tests

        #region GetVehicle_2 Tests

        [TestMethod]
        public void GetVehicle_2_VehicleFound()
        {
            //Arrange
            var gh = new GarageHandler();
            gh.CreatGarage();
            var regNoToFind = "ABC123";

            //Act
            var result = gh.GetVehicle_2(regNoToFind);

            //Assert
            Assert.AreEqual(regNoToFind, result.RegNo);
        }

        [TestMethod]
        public void GetVehicle_2_VehicleNOTFound()
        {
            //Arrange
            var gh = new GarageHandler();
            gh.CreatGarage();
            var regNoToFind = "NotFoundRegNo";

            //Act
            var result = gh.GetVehicle_2(regNoToFind);

            //Assert
            Assert.IsNull(result);
            //Assert.AreEqual(regNoToFind, result.RegNo);
        }

        [TestMethod]
        public void GetVehicle_2_VehicleNORegNo()
        {
            //Arrange
            var gh = new GarageHandler();
            gh.CreatGarage();
            var regNoToFind = "";

            //Act
            var result = gh.GetVehicle_2(regNoToFind);

            //Assert
            Assert.IsNull(result);
            //Assert.AreEqual(regNoToFind, result.RegNo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetVehicle_2_VehicleNullRegNo_throws()
        {
            //Arrange
            var gh = new GarageHandler();
            gh.CreatGarage();
            string? regNoToFind = null;

            //Act
            _ = gh.GetVehicle_2(regNoToFind!);

            //Assert
        }

        #endregion GetVehicle_2 Tests
    }
}
