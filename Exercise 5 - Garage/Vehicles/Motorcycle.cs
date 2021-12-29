using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5___Garage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle(string regNo) : base(regNo)
        {
        }

        public int CylinderVolume { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Cylinder volume {CylinderVolume} cc";
        }
    }
}
