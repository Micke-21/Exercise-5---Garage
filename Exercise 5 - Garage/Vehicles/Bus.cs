using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5___Garage.Vehicles
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Number of seats {NumberOfSeats}";
        }
    }
}
