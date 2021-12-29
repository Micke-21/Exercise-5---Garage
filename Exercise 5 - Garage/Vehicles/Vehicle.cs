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

        public Vehicle(string? regNo/*, string make, string model, string color, int noOfWheel*/)
        {
            RegNo = regNo;
            //Make = make;
            //Model = model;
            //Color = color;
            //NoOfWheel = noOfWheel;
        }

        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }

        public string RegNo
        {
            get => regNo;
            private set
            {
                //if (value == null)
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(RegNo), "Reg no already exists");
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
