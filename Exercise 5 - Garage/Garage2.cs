using Exercise_5___Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Garage.Tests")]
namespace Exercise_5___Garage
{

    internal class Garage2<T> : IGarage2<T>, IEnumerable<T> where T : Vehicle
    {
        //private readonly Vehicle[] vehicles;
        private readonly T[] vehicles;

        public int Capacity { get;/* set;*/ }

        public bool IsFull => Capacity <= Count();
        public int FreePlaces => Capacity - Count();

        private int Count()
        {
            var noOfVehicles = vehicles.Where((v) => v != null).Count();
            return noOfVehicles;
        }

        public Garage2(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[Capacity];
        }

        public T[] GetAllVehicle()
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


        public T? GetVehicleByRegNo(string regNo)
        {
            //var vehicle = vehicles.Where(v => v.RegNo == regNo.ToUpper()).ToArray();
            var vehicle = vehicles.FirstOrDefault((v) => v != null
            //&& v.RegNo == regNo.ToUpper()
            );
            return vehicle;
        }

        public bool IsRegNoFound(string regNo)
        {
            //For debugging
            //var reg = vehicles.Where((v) => v != null
            //&& v.RegNo == regNo
            //);
            //var c = reg.Count();

            //return c > 0;

            bool i = vehicles.Where((v) => v != null && v.RegNo == regNo).Any();
            return i;
        }

        public bool AddVehicle(T vehicle)
        {
            if (IsFull /*|| IsRegNoFound(vehicle.RegNo)*/)
                return false;

            //Todo Kolla så att inte regnummer redan finns!
            if (IsRegNoFound(vehicle.RegNo))
                throw new ArgumentException("Reg no alrady in Garage, call police ");

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
                if (vehicles[i] != null /*&& vehicles[i].RegNo == regNo.ToUpper()*/)
                {
                    vehicles[i] = default;// null;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                // ...
                if(item != null) yield return item;
                //yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        #region SeedVehicles
        public void SeedVehicles()
        {
            //var seedMethode = 1;

            //if (seedMethode == 1)  // Kan få Null värden mitt i listan
            //{
            //    vehicles[0] = new Vehicle() { Color = "Green", RegNo = "ABC123" };
            //    vehicles[1] = new Vehicle() { Color = "Blue", RegNo = "MLB061" };
            //    //vehicles[2] = new Vehicle() { Color = "Blue", RegNo = "MLB061" };
            //    //vehicles[2] = new Vehicle() { Color = "Blue", RegNo = "MLB062" };
            //    vehicles[3] = new Vehicle() { Color = "Blue", RegNo = "MLB063" };
            //    vehicles[4] = new Airplane() { Make = "Dynamic", Model = "WT-9", NoOfWheel = 3, Color = "Blue", RegNo = "SE-VPU", NumberOfEngines = 1, WingSpan = 9.00M };
            //    vehicles[5] = new Boat() { Make = "Swan", Model = "12a", Color = "White", RegNo = "SE6045", Lenght = 35, NoOfWheel = 0 };
            //    vehicles[6] = new Bus() { Make = "Volvo", Model = "X7", Color = "Blue", RegNo = "BUS101", NoOfWheel = 6, NumberOfSeats = 56 };
            //    vehicles[7] = new Car() { Make = "Volvo", Model = "XC90", Color = "Blue", RegNo = "TEST", Fueltype = "E85", NoOfWheel = 4 };
            //    vehicles[8] = new Motorcycle() { Make = "Honda", Model = "CB-125", Color = "Black", RegNo = "MC406", NoOfWheel = 2, CylinderVolume = 125 };
            //}

            //if (seedMethode == 2) // ev null i slutet av listan (fyller på från början av arrayen)
            //{
            //    Vehicle[] seedVehicles = {
            //        new Vehicle() { Color = "Green", RegNo = "ABC123" },
            //        new Vehicle() { Color = "Blue", RegNo = "MLB061" },
            //        //new Vehicle() { Color = "Blue", RegNo = "MLB061" },
            //        //new Vehicle() { Color = "Blue", RegNo = "MLB062" },
            //        //new Vehicle() { Color = "Blue", RegNo = "MLB063" },
            //        new Airplane() { Make ="Dynamic",Model = "WT-9", Color = "Blue", RegNo = "SE-VPU", NumberOfEngines = 1, WingSpan = 9.00M },
            //        new Boat() { Make ="Swan", Model = "12a", Color = "White", RegNo = "SE6045", Lenght = 35, NoOfWheel = 0 },
            //        new Bus() { Make = "Volvo", Model = "X2000", Color = "Blue", RegNo = "BUS101", NoOfWheel = 6, NumberOfSeats = 56 },
            //        new Car() { Make = "Volvo", Model = "XC90", Color = "Blue",  RegNo = "TEST", Fueltype = "E85", NoOfWheel = 4 },
            //        new Motorcycle() { Make = "Honda", Model = "CB-125", Color = "Blue", RegNo = "MC406", NoOfWheel = 2, CylinderVolume = 125 }
            //    };

            //    var i = 0;
            //    foreach (var vehicle in seedVehicles)
            //    {
            //        vehicles[i++] = vehicle;
            //    }
            //}

            //if (seedMethode == 3)// Using the addmethode
            //{
            //    AddVehicle(new Vehicle() { Color = "Green", RegNo = "ABC123" });
            //    AddVehicle(new Vehicle() { Color = "Blue", RegNo = "MLB061" });
            //    //AddVehicle(new Vehicle() { Color = "Blue", RegNo = "MLB061" });
            //    //AddVehicle(new Vehicle() { Color = "Blue", RegNo = "MLB062" });
            //    //AddVehicle(new Vehicle() { Color = "Blue", RegNo = "MLB063" });
            //    AddVehicle(new Airplane() { Make = "Dynamic", Model = "WT-9", Color = "Blue", RegNo = "SE-VPU", NumberOfEngines = 1, WingSpan = 9.00M });
            //    AddVehicle(new Boat() { Make = "Swan", Model = "12a", Color = "White", RegNo = "SE6045", Lenght = 35, NoOfWheel = 0 });
            //    AddVehicle(new Bus() { Make = "Volvo", Model = "X2000", Color = "Blue", RegNo = "BUS101", NoOfWheel = 6, NumberOfSeats = 56 });
            //    AddVehicle(new Car() { Make = "Volvo", Model = "XC90", Color = "Blue", RegNo = "TEST", Fueltype = "E85", NoOfWheel = 4 });
            //    AddVehicle(new Motorcycle() { Make = "Honda", Model = "CB-125", Color = "Blue", RegNo = "MC406", NoOfWheel = 2, CylinderVolume = 125 });
            //}
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
