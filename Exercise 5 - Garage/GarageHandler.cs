using Exercise_5___Garage.Vehicles;
using System.Text;

namespace Exercise_5___Garage
{
    public class GarageHandler : IGarageHandler
    {
        private readonly int capacity = 9;
        private IGarage<Vehicle> garage;


        public GarageHandler()
        {

        }

        public void CreatGarage()
        {
            CreatGarage(capacity);
        }

        public void CreatGarage(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
            //garage.SeedVehicles();
            SeedVehicles();
        }

        public bool IsGarageFull()
        {
            //var g = garage.IsFull;
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
            //if (string.IsNullOrWhiteSpace(regNo))
            if (regNo is null)
                throw new ArgumentNullException(nameof(regNo), "Reg no can't be null.");
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

        public string GetVehicleTypes_3()
        {
            var vehicles = garage.GetAllVehicle();
            string vehicleTypes = "";
            var res = vehicles.GroupBy(v => v.GetType().Name)
                .Select(v => new
                {
                    Name = v.Key,
                    NoOfType = v.Count()

                })
                .Select(s => $"Name: {s.Name} \t\tCount: {s.NoOfType}");
            //.ToString();

            var sb = new StringBuilder();

            foreach (var item in res)
                sb.AppendLine(item);

            return sb.ToString();
        }
        public bool GarageIsCreated()
        {
            return garage != null;
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
            var newVehicle = new Car("DEF123") { /*RegNo = "DEF123",*/ Color = "Color", Make = "Test", Fueltype = "E85", Model = "T1", NoOfWheel = 6 };

            return garage.AddVehicle(newVehicle);
        }

        /// <summary>
        /// Used for adding vehicles to the garage
        /// Gör typ samma sak för varje fordonstyp!
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        public bool AddVehicle_old(IUI ui, string choice)
        {
            string? regNo = ui.GetStringInput("Enter Reg no: ");
            //ToDo Kolla om regnummer finns!?
            if (string.IsNullOrEmpty(regNo))
            {
                ui.GetKey("Reg no not valid or already found");
                return false;
            }
            if (garage.IsRegNoInGarage(regNo))
            {
                //ui.PrintString("Reg no not valid or already found");
                ui.GetKey("Reg no already found");
                return false;
            }
            var make = ui.GetStringInput("Enter Make: ");
            var model = ui.GetStringInput("Enter Model: ");
            var color = ui.GetStringInput("Enter Color: ");
            var noWheel = int.TryParse(ui.GetStringInput("Enter number of whells: "), out int iow) ? iow : 0;

            //ToDo GarageHandler: Jag har Scope problem vill egentligen inte skapa upp så här många objekt! 
            var newVehicle = new Vehicle(regNo);
            var newAirplane = new Airplane(regNo);
            var newBoat = new Boat(regNo);
            var newBus = new Bus(regNo);
            var newCar = new Car(regNo);
            var newMotorcycle = new Motorcycle(regNo);

            bool vehicleadded = false;

            switch (choice)
            {
                case "1":
                    //newVehicle.RegNo = regNo;
                    newVehicle.Make = make;
                    newVehicle.Model = model;
                    newVehicle.Color = color;
                    newVehicle.NoOfWheel = noWheel;

                    vehicleadded = garage.AddVehicle(newVehicle);
                    break;
                case "2": //Airplane
                    //newAirplane.RegNo = regNo;
                    newAirplane.Make = make;
                    newAirplane.Model = model;
                    newAirplane.Color = color;
                    newAirplane.NoOfWheel = noWheel;

                    var wingspan = ui.GetStringInput("Enter WingSpan: ");
                    var noEngines = ui.GetStringInput("Enter No of Engines: ");
                    //var test = decimal.Parse(wingspan);
                    newAirplane.WingSpan = decimal.TryParse(wingspan, out decimal w) ? w : 0;
                    newAirplane.NumberOfEngines = int.TryParse(noEngines, out int noe) ? noe : 0;

                    vehicleadded = garage.AddVehicle(newAirplane);
                    break;
                case "3": //Boat
                    //newBoat.RegNo = regNo;
                    newBoat.Make = make;
                    newBoat.Model = model;
                    newBoat.Color = color;
                    newBoat.NoOfWheel = noWheel;

                    var length = ui.GetStringInput("Enter Lenght: ");
                    newBoat.Lenght = int.TryParse(length, out int l) ? l : 0;

                    vehicleadded = garage.AddVehicle(newBoat);
                    break;
                case "4": //Bus
                    //newBus.RegNo = regNo;
                    newBus.Make = make;
                    newBus.Model = model;
                    newBus.Color = color;
                    newBus.NoOfWheel = noWheel;

                    var noSeats = ui.GetStringInput("Enter Number of Seats: ");
                    newBus.NumberOfSeats = int.TryParse(noSeats, out int nos) ? nos : 0;

                    vehicleadded = garage.AddVehicle(newBus);
                    break;
                case "5": //Car
                    //newCar.RegNo = regNo;
                    newCar.Make = make;
                    newCar.Model = model;
                    newCar.Color = color;
                    newCar.NoOfWheel = noWheel;

                    var fueltype = ui.GetStringInput("Enter FuelType: ");
                    newCar.Fueltype = fueltype;

                    vehicleadded = garage.AddVehicle(newCar);
                    break;
                case "6": //Motorcycle
                    //newMotorcycle.RegNo = regNo;
                    newMotorcycle.Make = make;
                    newMotorcycle.Model = model;
                    newMotorcycle.Color = color;
                    newMotorcycle.NoOfWheel = noWheel;

                    var cylindeVol = ui.GetStringInput("Enter CylinderVolume:");
                    newMotorcycle.CylinderVolume = int.TryParse(cylindeVol, out int cv) ? cv : 0;

                    vehicleadded = garage.AddVehicle(newMotorcycle);
                    break;

                default:
                    break;
            }

            return vehicleadded;
        }

        //Ny metod för att testa att ta bort repetiv kod
        public bool AddVehicle(IUI ui, string choice)
        {
            string? regNo = ui.GetStringInput("Enter Reg no: ");
            //ToDo Kolla om regnummer finns!?
            if (string.IsNullOrEmpty(regNo))
            {
                ui.GetKey("Reg no not valid or already found");
                return false;
            }
            if (garage.IsRegNoInGarage(regNo))
            {
                //ui.PrintString("Reg no not valid or already found");
                ui.GetKey("Reg no already found");
                return false;
            }
            var make = ui.GetStringInput("Enter Make: ");
            var model = ui.GetStringInput("Enter Model: ");
            var color = ui.GetStringInput("Enter Color: ");
            var noWheel = int.TryParse(ui.GetStringInput("Enter number of whells: "), out int iow) ? iow : 0;

            //ToDo GarageHandler: Jag har Scope problem vill egentligen inte skapa upp så här många objekt! 

            bool vehicleadded = false;

            IVehicle? vehicle = null;


            switch (choice)
            {
                case "1":
                    vehicle = new Vehicle(regNo);

                    break;
                case "2": //Airplane
                    var airplane = new Airplane(regNo);

                    var wingspan = ui.GetStringInput("Enter WingSpan: ");
                    var noEngines = ui.GetStringInput("Enter No of Engines: ");

                    airplane.WingSpan = decimal.TryParse(wingspan, out decimal w) ? w : 0;
                    airplane.NumberOfEngines = int.TryParse(noEngines, out int noe) ? noe : 0;

                    vehicle = airplane;
                    break;
                case "3": //Boat
                    var boat = new Boat(regNo);

                    var length = ui.GetStringInput("Enter Lenght: ");
                    boat.Lenght = int.TryParse(length, out int l) ? l : 0;

                    vehicle = boat;
                    break;
                case "4": //Bus
                    var bus = new Bus(regNo);

                    var noSeats = ui.GetStringInput("Enter Number of Seats: ");
                    bus.NumberOfSeats = int.TryParse(noSeats, out int nos) ? nos : 0;

                    vehicle = bus;
                    break;
                case "5": //Car
                    var car = new Car(regNo);
                    var fueltype = ui.GetStringInput("Enter FuelType: ");
                    car.Fueltype = fueltype;

                    vehicle = car;
                    break;
                case "6": //Motorcycle
                    var motorcycle = new Motorcycle(regNo);
                    var cylindeVol = ui.GetStringInput("Enter CylinderVolume:");
                    motorcycle.CylinderVolume = int.TryParse(cylindeVol, out int cv) ? cv : 0;

                    vehicle = motorcycle;
                    break;

                    //default:
                    //    break;
            }

            if (vehicle != null)
            {
                vehicle.Make = make;
                vehicle.Model = model;
                vehicle.Color = color;
                vehicle.NoOfWheel = noWheel;

                vehicleadded = garage.AddVehicle((Vehicle)vehicle);
                if (vehicleadded)
                    ui.PrintVehicle((Vehicle)vehicle);
            }

            return vehicleadded;
        }


        /// <summary>
        /// En test medtod för att testa lite saker under utvecklingen.
        /// </summary>
        public void Test()
        {
            Console.Clear();
            Console.WriteLine("TEST METOD");
            var regno = "MLB063";

            if (garage.IsRegNoInGarage(regno))
                Console.WriteLine($"Regno {regno} finns redan");
            else
                Console.WriteLine($"Regno {regno} finns ej");

            //var isFullText = garage.IsFull ? "Yes" : "No";
            Console.WriteLine($"Garage is  {(garage.IsFull ? "full" : "not full")}");

            Console.WriteLine($"Qapacity {garage.Capacity} Free Places {garage.FreePlaces}");
        }

        #region SeedVehicles
        public void SeedVehicles()
        {
            var seedMethode = 3;

            //Denna funar då den använder funktionen för att lägga till fordon!
            if (seedMethode == 3)// Using the addmethode
            {
                garage.AddVehicle(new Vehicle(regNo: "ABC123") { Make = "SAAB", Model = "V4", NoOfWheel = 4, Color = "Green" });
                garage.AddVehicle(new Vehicle(regNo: "MLB061") { Color = "Blue"});
                //garage.AddVehicle(new Vehicle(regNo: "MLB061") { Color = "Blue" });
                //garage.AddVehicle(new Vehicle(regNo: "MLB062") { Color = "Blue" });
                //garage.AddVehicle(new Vehicle(regNo: "MLB063") { Color = "Blue" });
                garage.AddVehicle(new Airplane(regNo: "SE-VPU") { Make = "Dynamic", Model = "WT-9", Color = "Blue", NumberOfEngines = 1, WingSpan = 9.00M });
                garage.AddVehicle(new Boat(regNo: "SE6045") { Make = "Swan", Model = "12a", Color = "White", Lenght = 35, NoOfWheel = 0 });
                garage.AddVehicle(new Bus(regNo: "BUS101") { Make = "Volvo", Model = "X2000", Color = "Blue", NoOfWheel = 6, NumberOfSeats = 56 });
                garage.AddVehicle(new Car(regNo: "TEST") { Make = "Volvo", Model = "XC90", Color = "Blue", Fueltype = "E85", NoOfWheel = 4 });
                garage.AddVehicle(new Motorcycle(regNo: "MC406") { Make = "Honda", Model = "CB-125", Color = "Blue", NoOfWheel = 2, CylinderVolume = 125 });
            }
            /*
            RegNo = "ABC123"
            RegNo = "MLB061"
            RegNo = "MLB062"
            RegNo = "MLB063"
            RegNo = "SE-VPU"
            RegNo = "SE6045"
            RegNo = "BUS101"
            RegNo = "TEST", 
            RegNo = "MC406"
                     DEF123
             */
        }

        #endregion SeedVehicles
    }
}
