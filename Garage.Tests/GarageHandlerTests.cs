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
            Mock<IGarage<Vehicle>> mg = new Mock<IGarage<Vehicle>>();
            mg.Setup(g => g.IsFull).Returns(true);

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
            Mock<IGarage<Vehicle>> mg = new Mock<IGarage<Vehicle>>();
            mg.Setup(g => g.IsFull).Returns(false);
            mg.Setup(g => g.GetVehicleByRegNo("")).Returns(new Car { Color = "Blue", RegNo = "QWE" });

            //Act
            var result = gh.GetVehicle("abs");
            //var result = gh.IsGarageFull();

            //Assert
            //Assert.IsFalse(result);

        }
    }
}
