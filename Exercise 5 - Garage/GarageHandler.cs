using Exercise_5___Garage.Vehicles;

namespace Exercise_5___Garage
{
    public class GarageHandler : IGarageHandler
    {
        private int capacity = 9;
        private IGarage<Vehicle> garage;


        public GarageHandler()
        {

        }
        public void CreatGarage()
        {
            //garage = new Garage<Vehicle>(capacity);
            //garage.SeedVehicles();

            CreatGarage(capacity);
        }

        public void CreatGarage(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
            garage.SeedVehicles();
        }

        public bool IsGarageFull()
        {
            var g = garage.IsFull;
            return garage.IsFull;
        }
        public Vehicle[] GetAllVehicles()
        {
            return garage.GetAllVehicle();
        }

        public Vehicle? GetVehicle(string regNo)
        {
            return garage.GetVehicleByRegNo(regNo);
        }

        public Vehicle? GetVehicle_2(string regNo)
        {
            if (regNo == null)
                throw new ArgumentNullException("Reg no can't be null.");
            var vehicles = garage.GetAllVehicle();
            var vehicle = vehicles.Where(v => v.RegNo == regNo.ToUpper()).FirstOrDefault();

            return vehicle;
        }

        public string GetVehicleTypes()
        {
            return garage.GetVehicleTypes();
        }

        public string GetVehicleTypes_2()
        {
            var vehicles = garage.GetAllVehicle();
            string vehicleTypes = "";

            foreach (var item in vehicles)
            {
                vehicleTypes += item != null ? item.GetType().Name : "* Null *";
                vehicleTypes += "\n";
            }

            return vehicleTypes;
        }

        public bool GarageIsCreated()
        {
            return garage != null ? true : false;
        }

        public bool RemoveVehicle(string regNo)
        {
            return garage.RemoveVehicle(regNo);
        }

        /// <summary>
        /// For test
        /// </summary>
        /// <returns>True if Vehicle is added</returns>
        public bool AddVehicle()
        {
            var newVehicle = new Car { RegNo = "DEF123", Color = "Color", Make = "Test", Fueltype = "E85", Model = "T1", NoOfWheel = 6 };

            return garage.AddVehicle(newVehicle);
        }

        /// <summary>
        /// Used for adding vehicles to the garage
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        public bool AddVehicle(IUI ui, string choice)
        {
            var newVehicle = new Vehicle();
            var newAirplane = new Airplane();
            var newBoat = new Boat();
            var newBus = new Bus();
            var newCar = new Car();
            var newMotorcycle = new Motorcycle();

            string? regNo = ui.GetStringInput("Enter Reg no: ");
            var make = ui.GetStringInput("Enter Make: ");
            var model = ui.GetStringInput("Enter Model: ");
            var color = ui.GetStringInput("Enter Color: ");
            var noWheel = int.TryParse(ui.GetStringInput("Enter number of whells: "), out int iow) ? iow : 0;

            bool result = false;

            switch (choice)
            {
                case "1":
                    newVehicle.RegNo = regNo;
                    newVehicle.Make = make;
                    newVehicle.Model = model;
                    newVehicle.Color = color;
                    newVehicle.NoOfWheel = noWheel;

                    result = garage.AddVehicle(newVehicle);
                    break;
                case "2": //Airplane
                    newAirplane.RegNo = regNo;
                    newAirplane.Make = make;
                    newAirplane.Model = model;
                    newAirplane.Color = color;
                    newAirplane.NoOfWheel = noWheel;

                    var wingspan = ui.GetStringInput("Enter WingSpan: ");
                    var noEngines = ui.GetStringInput("Enter No of Engines: ");
                    var test = decimal.Parse(wingspan);
                    newAirplane.WingSpan = decimal.TryParse(wingspan, out decimal w) ? w : 0;
                    newAirplane.NumberOfEngines = int.TryParse(noEngines, out int noe) ? noe : 0;

                    result = garage.AddVehicle(newAirplane);
                    break;
                case "3": //Boat
                    newBoat.RegNo = regNo;
                    newBoat.Make = make;
                    newBoat.Model = model;
                    newBoat.Color = color;
                    newBoat.NoOfWheel = noWheel;

                    var length = ui.GetStringInput("Enter Lenght: ");
                    newBoat.Lenght = int.TryParse(length, out int l) ? l : 0;

                    result = garage.AddVehicle(newBoat);
                    break;
                case "4": //Bus
                    newBus.RegNo = regNo;
                    newBus.Make = make;
                    newBus.Model = model;
                    newBus.Color = color;
                    newBus.NoOfWheel = noWheel;

                    var noSeats = ui.GetStringInput("Enter Number of Seats: ");
                    newBus.NumberOfSeats = int.TryParse(noSeats, out int nos) ? nos : 0;

                    result = garage.AddVehicle(newBus);
                    break;
                case "5": //Car
                    newCar.RegNo = regNo;
                    newCar.Make = make;
                    newCar.Model = model;
                    newCar.Color = color;
                    newCar.NoOfWheel = noWheel;

                    var fueltype = ui.GetStringInput("Enter FuelType: ");
                    newCar.Fueltype = fueltype;

                    result = garage.AddVehicle(newCar);
                    break;
                case "6": //Motorcycle
                    newMotorcycle.RegNo = regNo;
                    newMotorcycle.Make = make;
                    newMotorcycle.Model = model;
                    newMotorcycle.Color = color;
                    newMotorcycle.NoOfWheel = noWheel;

                    var cylindeVol = ui.GetStringInput("Enter CylinderVolume:");
                    newMotorcycle.CylinderVolume = int.TryParse(cylindeVol, out int cv) ? cv : 0;

                    result = garage.AddVehicle(newMotorcycle);
                    break;

                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// En test medtod för att testa lite saker under utvecklingen.
        /// </summary>
        public void Test()
        {
            Console.Clear();
            Console.WriteLine("TEST METOD");
            var regno = "MLB063";

            if (garage.IsRegNoFound(regno))
                Console.WriteLine($"Regno {regno} finns redan");
            else
                Console.WriteLine($"Regno {regno} finns ej");

            var isFullText = garage.IsFull ? "Yes" : "No";
            Console.WriteLine($"Garage is  {(garage.IsFull ? "full" : "not full")}");

            Console.WriteLine($"Qapacity {garage.Capacity} Free Places {garage.FreePlaces}");
        }
    }
}
