namespace Exercise_5___Garage
{
    //ToDo Manager: Dela upp denna funktion???
    internal class Manager
    {
        private readonly IUI ui;
        private readonly IGarageHandler gh;

        // startar som "vanlig"
        public Manager()
        {
            gh = new GarageHandler();
            ui = new UI();
        }

        //Start via DI
        public Manager(IUI ui, IGarageHandler garageHandler)
        {
            gh = garageHandler;
            this.ui = ui;
        }

        internal void Run()
        {

            var exit = false;
            do
            {
                if (!gh.GarageIsCreated())
                {
                    ui.ShowStartMenu();
                    var choice = ui.GetMenuChoice();
                    switch (choice)
                    {
                        case "1":
                            gh.CreatGarage();
                            break;
                        case "2":
                            string? stringInput = ui.GetStringInput("How many parkingplaces should the garage have? ");
                            int capacity = int.TryParse(stringInput, out capacity) ? capacity : 0;
                            gh.CreatGarage(capacity);
                            break;

                        case "q":
                        case "Q":
                            exit = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ui.ShowMenu();

                    var choice = ui.GetMenuChoice();
                    string? regno;

                    switch (choice)
                    {
                        //Console.WriteLine("1. List all vehicles.");
                        case "1":
                            ui.ListAllVehicles(gh.GetAllVehicles());
                            ui.GetKey("\nPress a key to continue.");
                            break;

                        //Console.WriteLine("2. List vehicle types.");
                        case "2":
                            var vehicleTypes = gh.GetVehicleTypes_3();
                            ui.PrintString("List of Vehicle types\n\n" + vehicleTypes);

                            ui.GetKey("\nPress a key to continue.");
                            break;

                        //Console.WriteLine("3. Add vehicle.");
                        case "3":
                            //Todo Kolla om garaget är fullt!?
                            //
                            if (gh.IsGarageFull())
                            {
                                ui.PrintString("Garage is full can´t add more vehicles.");
                            }
                            else
                            {
                                ui.ChoseVehicleToAdd();
                                choice = ui.GetMenuChoice();

                                if (gh.AddVehicle(ui, choice!))

                                    ui.PrintString("Vehicle added.");
                                else
                                    ui.PrintString("Vehcile not added");
                            }

                            ui.GetKey("\nPress a key to continue.");
                            break;

                        //Console.WriteLine("4. Remove vehicle");
                        case "4":
                            regno = ui.GetStringInput("Enter Reg no to remove");
                            if (gh.RemoveVehicle(regno!))
                                ui.PrintString("Vehicle removed.");
                            else
                                ui.PrintString("Vehcile not removed");

                            ui.GetKey("\nPress a key to continue.");

                            break;

                        //Console.WriteLine("5. Find vehicle");
                        case "5":
                            regno = ui.GetStringInput("Enter Reg no to find");

                            var vehicle = gh.GetVehicle_2(regno);
                            ui.PrintVehicle(vehicle);
                            ui.GetKey("\nPress a key to continue.");
                            break;
                        case "6":

                            break;
                        case "0":
                            gh.Test();
                            ui.GetKey("\nPress a key to continue.");
                            break;

                        case "q":
                        case "Q":
                            exit = true;
                            break;
                        default:
                            break;
                    }
                }
            } while (!exit);

        }
    }
}
