using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5___Garage.Vehicles
{
    internal class Airplane : Vehicle
    {
        public Airplane(string regNo) : base(regNo)
        {
        }

        public decimal WingSpan { get; set; }

        public int NumberOfEngines { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" WingSpan: {WingSpan} m, Number of engines {NumberOfEngines}";
        }
    }
}
