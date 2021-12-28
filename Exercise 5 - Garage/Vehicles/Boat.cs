using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5___Garage.Vehicles
{
    internal class Boat : Vehicle
    {
        public int Lenght { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Lengt {Lenght} ft";
        }
    }

}
