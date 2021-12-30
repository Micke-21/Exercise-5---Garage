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
            && v.RegNo == regNo.ToUpper()
            );

            //var vehicle = vehicles.FirstOrDefault((v) => v.RegNo == regNo.ToUpper());

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
                //yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
