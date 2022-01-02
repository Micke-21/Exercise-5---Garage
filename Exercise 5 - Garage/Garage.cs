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

    internal class Garage<T> : IGarage<T>, IEnumerable<T> where T : Vehicle
    {
        private readonly T[] vehicles;

        public int Capacity { get;/* set;*/ }

        public bool IsFull => Capacity <= Count();
        public int FreePlaces => Capacity - Count();

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[Capacity];
        }

        /// <summary>
        /// Get the number of vehicles in the Garage
        /// </summary>
        /// <returns>The number of vehicles in the Garage</returns>
        private int Count()
        {
            var noOfVehicles = vehicles.Where((v) => v != null).Count();
            return noOfVehicles;
        }


        /// <summary>
        /// Ge all Vehicles
        /// </summary>
        /// <returns>Returns all parked Vehicles</returns>
        public T[] GetAllVehicle()
        {
            var v = vehicles.Where(v => v != null).ToArray();
            return v;
        }

        /// <summary>
        /// Get VehicleTypes
        /// </summary>
        /// <returns>Returns a string whit the vehicle types</returns>
        /// <remarks></remarks>
        [Obsolete("Use the Methode in GarageHandler istead")]
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

        /// <summary>
        /// Get vehicle be the registration number
        /// </summary>
        /// <param name="regNo">Reg no to search</param>
        /// <returns>Returns the Vehicle</returns>
        public T? GetVehicleByRegNo(string regNo)
        {
            var vehicle = vehicles.FirstOrDefault((v) => v != null && v.RegNo == regNo.ToUpper());

            //var vehicle = vehicles.FirstOrDefault((v) => v.RegNo == regNo.ToUpper());

            return vehicle;
        }

        /// <summary>
        /// Test if the registration number alrady are in the Garage
        /// </summary>
        /// <param name="regNo">Reg no to test</param>
        /// <returns>True if the reg no alrady in the garage outerthise False</returns>
        public bool IsRegNoInGarage(string regNo)
        {
            //For debugging
            //var reg = vehicles.Where((v) => v != null
            //&& v.RegNo == regNo
            //);
            //var c = reg.Count();

            //return c > 0;

            bool i = vehicles.Where((v) => v != null && v.RegNo == regNo.ToUpper()).Any();
            return i;
        }

        /// <summary>
        /// Add (park) a vehicle in the Garage
        /// </summary>
        /// <param name="vehicle">Vehicle to park</param>
        /// <returns>True if vehicle parked ok, False not parked</returns>
        /// <exception cref="ArgumentException"></exception>
        public bool AddVehicle(T vehicle)
        {
            if (IsFull)
                return false;

            //Todo Kolla så att inte regnummer redan finns!
            if (IsRegNoInGarage(vehicle.RegNo))
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

        /// <summary>
        /// Remove vehicle by registration number
        /// </summary>
        /// <param name="regNo">Reg no to remove/unpark</param>
        /// <returns>True if vehicle removed ok, False not removed</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool RemoveVehicle(string regNo)
        {
            if (regNo == null)
                throw new ArgumentNullException(nameof(regNo), "No reg no passed");

            for (var i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null && vehicles[i].RegNo == regNo.ToUpper())
                {
                    vehicles[i] = default;// null;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove/unpark Vehicle by a Vehicle object
        /// </summary>
        /// <param name="vehicle">The Vehicle to remove/unpark</param>
        /// <returns>True if vehicle removed ok, False not removed</returns>
        /// <exception cref="ArgumentNullException">Throws if the vehicle is null</exception>
        public bool RemoveVehicle(T vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle), "No vehicle passed");

            for (var i = 0; i < Capacity; i++)
            {
                //ToDo är null kollen nådvändig? Nu när jag fått IEnemerable att funka!
                if (vehicles[i] != null && vehicles[i] == vehicle)
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
                if (item != null) yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
