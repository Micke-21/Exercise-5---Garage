using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_5___Garage;

namespace Exercise_5___Garage.Vehicles
{
    public class Vehicle
    {
        private string regNo;

        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegNo
        {
            get => regNo;
            set
            {

                //if (IsRegNoFound(value))
                //    throw new ArgumentException("Reg no already exists");
                if (value == null)
                    throw new ArgumentNullException("Reg no already exists");
                regNo = value.ToUpper();
            }
        }
        public int NoOfWheel { get; set; }

        public override string ToString()
        {
            string vehicleString = $"Make: {Make}, Model: {Model}, ";
            vehicleString += $"Reg no: {RegNo}, Color: {Color}, No of wheel: {NoOfWheel}.";
            return vehicleString;
        }

    }
}
