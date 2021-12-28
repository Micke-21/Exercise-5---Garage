using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5___Garage.Vehicles
{
    internal class Car : Vehicle
    {
        public string Fueltype { get; set; }

        public override string ToString()
        {
            return base.ToString() +$" Fuel type {Fueltype}";
        }
    }
}
