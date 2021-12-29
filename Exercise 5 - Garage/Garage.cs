﻿using Exercise_5___Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Garage.Tests")]
namespace Exercise_5___Garage
{

    internal class Garage<T> : IGarage<T> //: IEnumerable<T>
    {
        private readonly Vehicle[] vehicles;
        //private readonly T[] vehicles;

        public int Capacity { get;/* set;*/ }

        public bool IsFull => Capacity <= Count();
        public int FreePlaces => Capacity - Count();

        private int Count()
        {
            var noOfVehicles = vehicles.Where((v) => v != null).Count();
            return noOfVehicles;
        }

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new Vehicle[Capacity];
        }

        public Vehicle[] GetAllVehicle()
        {
            var v = vehicles.Where(v => v != null).ToArray();
            return v;
        }

        public string GetVehicleTypes()
        {
            var f = vehicles.Select((v) => v.GetType().Name.GroupBy(g => g.GetType().Name));
            string vehicleTypes = "";

            foreach (var v in vehicles)
            {
                //ToDo GetVehicleTypes: Hur skall den retruneras? Som sträng? eller något annat sätt?
                vehicleTypes += v != null ? v.GetType().Name : "* Null *";
                vehicleTypes += "\n";
            }

            return vehicleTypes;
        }


        public Vehicle? GetVehicleByRegNo(string regNo)
        {
            //var vehicle = vehicles.Where(v => v.RegNo == regNo.ToUpper()).ToArray();
            var vehicle = vehicles.FirstOrDefault((v) => v != null && v.RegNo == regNo.ToUpper());
            return vehicle;
        }

        public bool IsRegNoFound(string regNo)
        {
            //For debugging
            var reg = vehicles.Where((v) => v != null && v.RegNo == regNo);
            var c = reg.Count();

            bool i = vehicles.Where((v) => v != null && v.RegNo == regNo).Any();
            return i;
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            if (IsFull || IsRegNoFound(vehicle.RegNo))
                return false;

            for (var i = 0; i < Capacity; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveVehicle(string regNo)
        {
            if (regNo == null)
                throw new ArgumentNullException(nameof(regNo), "No reg no passed");
            
            for (var i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null && vehicles[i].RegNo == regNo.ToUpper())
                {
                    vehicles[i] = null;
                    return true;
                }
            }
            return false;
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    foreach (var item in vehicles)
        //    {
        //        // ...  
        //        //yield return item;
        //    }
        //}

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}


        #region SeedVehicles
        public void SeedVehicles()
        {
            var seedMethode = 2;

            //ToDo SeedVehicles Index out of range if capacity < see down
            if (seedMethode == 1)  // Kan få Null värden mitt i listan
            {
                
                vehicles[0] = new Vehicle(regNo: "ABC123") { Make = "SAAB", Model = "V4", NoOfWheel = 4, Color = "Green"/*, RegNo = "ABC123"*/ };
                vehicles[1] = new Vehicle(regNo: "MLB061") { Color = "Blue"/*, RegNo = "MLB061"*/ };
                //vehicles[2] = new Vehicle() { Color = "Blue", RegNo = "MLB061" };
                //vehicles[2] = new Vehicle() { Color = "Blue", RegNo = "MLB062" };
                vehicles[3] = new Vehicle(regNo: "MLB063") { Color = "Blue"/*, RegNo = "MLB063"*/ };
                vehicles[4] = new Airplane(regNo: "SE-VPU") { Make = "Dynamic", Model = "WT-9", NoOfWheel = 3, Color = "Blue"/*, RegNo = "SE-VPU"*/, NumberOfEngines = 1, WingSpan = 9.00M };
                vehicles[5] = new Boat(regNo: "SE6045") { Make = "Swan", Model = "12a", Color = "White", /*RegNo = "SE6045",*/ Lenght = 35, NoOfWheel = 0 };
                vehicles[6] = new Bus(regNo: "BUS101") { Make = "Volvo", Model = "X7", Color = "Blue", /*RegNo = "BUS101",*/ NoOfWheel = 6, NumberOfSeats = 56 };
                vehicles[7] = new Car(regNo: "TEST") { Make = "Volvo", Model = "XC90", Color = "Blue", /*RegNo = "TEST",*/ Fueltype = "E85", NoOfWheel = 4 };
                vehicles[8] = new Motorcycle(regNo: "MC406") { Make = "Honda", Model = "CB-125", Color = "Black", /*RegNo = "MC406",*/ NoOfWheel = 2, CylinderVolume = 125 };
            }

            if (seedMethode == 2) // ev null i slutet av listan (fyller på från början av arrayen)
            {
                Vehicle[] seedVehicles = {
                    new Vehicle(regNo: "ABC123") { Make = "SAAB", Model = "V4", NoOfWheel = 4, Color = "Green"/*, RegNo = "ABC123"*/ },
                    new Vehicle(regNo: "MLB061") { Color = "Blue"/*, RegNo = "MLB061"*/ },
                    //new Vehicle() { Color = "Blue", RegNo = "MLB061" },
                    //new Vehicle() { Color = "Blue", RegNo = "MLB062" },
                    //new Vehicle() { Color = "Blue", RegNo = "MLB063" },
                    new Airplane(regNo: "SE-VPU") { Make ="Dynamic",Model = "WT-9", Color = "Blue", /*RegNo = "SE-VPU",*/ NumberOfEngines = 1, WingSpan = 9.00M },
                    new Boat(regNo: "SE6045") { Make ="Swan", Model = "12a", Color = "White", /*RegNo = "SE6045",*/ Lenght = 35, NoOfWheel = 0 },
                    new Bus(regNo: "BUS101") { Make = "Volvo", Model = "X2000", Color = "Blue", /*RegNo = "BUS101",*/ NoOfWheel = 6, NumberOfSeats = 56 },
                    new Car(regNo: "TEST") { Make = "Volvo", Model = "XC90", Color = "Blue",  /*RegNo = "TEST",*/ Fueltype = "E85", NoOfWheel = 4 },
                    new Motorcycle(regNo: "MC406") { Make = "Honda", Model = "CB-125", Color = "Blue",/* RegNo = "MC406",*/ NoOfWheel = 2, CylinderVolume = 125 }
                };

                //ToDo SeedVehicles Index out of range if capacity < see down
                var i = 0;
                foreach (var vehicle in seedVehicles)
                {
                    if (i >= Capacity)
                        break;
                    vehicles[i++] = vehicle;
                }
            }

            if (seedMethode == 3)// Using the addmethode
            {
                AddVehicle(new Vehicle(regNo: "ABC123") { Make = "SAAB", Model = "V4", NoOfWheel = 4, Color = "Green"/*, RegNo = "ABC123"*/ });
                AddVehicle(new Vehicle(regNo: "MLB061") { Color = "Blue"/*, RegNo = "MLB061"*/ });
                //AddVehicle(new Vehicle() { Color = "Blue", RegNo = "MLB061" });
                //AddVehicle(new Vehicle() { Color = "Blue", RegNo = "MLB062" });
                //AddVehicle(new Vehicle() { Color = "Blue", RegNo = "MLB063" });
                AddVehicle(new Airplane(regNo: "SE-VPU") { Make = "Dynamic", Model = "WT-9", Color = "Blue"/*, RegNo = "SE-VPU"*/, NumberOfEngines = 1, WingSpan = 9.00M });
                AddVehicle(new Boat(regNo: "SE6045") { Make = "Swan", Model = "12a", Color = "White"/*, RegNo = "SE6045"*/, Lenght = 35, NoOfWheel = 0 });
                AddVehicle(new Bus(regNo: "BUS101") { Make = "Volvo", Model = "X2000", Color = "Blue"/*, RegNo = "BUS101"*/, NoOfWheel = 6, NumberOfSeats = 56 });
                AddVehicle(new Car(regNo: "TEST") { Make = "Volvo", Model = "XC90", Color = "Blue"/*, RegNo = "TEST"*/, Fueltype = "E85", NoOfWheel = 4 });
                AddVehicle(new Motorcycle(regNo: "MC406") { Make = "Honda", Model = "CB-125", Color = "Blue"/*, RegNo = "MC406"*/, NoOfWheel = 2, CylinderVolume = 125 });
            }
            /*
            RegNo = "ABC123"
            RegNo = "MLB061"
            RegNo = "MLB062"
            RegNo = "MLB063"
            RegNo = "SE-VPU"
            RegNo = "SE6045"
            RegNo = "BUS101"
            RegNo = "TEST", 
            RegNo = "MC406"
                     DEF123
             */
        }


        #endregion SeedVehicles

    }
}