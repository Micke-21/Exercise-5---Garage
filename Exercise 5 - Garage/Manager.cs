using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5___Garage
{
    internal class Manager
    {
        internal void Run()
        {
            var gh = new GarageHandler();
            IUI ui = new UI();
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
                    string regno;

                    switch (choice)
                    {
                        //Console.WriteLine("1. List all vehicles.");
                        case "1":
                            ui.ListAllVehicles(gh.GetAllVehicles());
                            ui.GetKey("\nPress a key to continue.");
                            break;

                        //Console.WriteLine("2. List vehicle types.");
                        case "2":
                            var vehicleTypes = gh.GetVehicleTypes();
                            ui.PrintString(vehicleTypes);

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

                                if (gh.AddVehicle(ui, choice))
                                    ui.PrintString("Vehicle added.");
                                else
                                    ui.PrintString("Vehcile not added");
                            }

                            ui.GetKey("\nPress a key to continue.");
                            break;

                        //Console.WriteLine("4. Remove vehicle");
                        case "4":
                            regno = ui.GetStringInput("Enter Reg no to remove");
                            if (gh.RemoveVehicle(regno))
                                ui.PrintString("Vehicle removed.");
                            else
                                ui.PrintString("Vehcile not removed");

                            ui.GetKey("\nPress a key to continue.");

                            break;

                        //Console.WriteLine("5. Find vehicle");
                        case "5":
                            regno = ui.GetStringInput("Enter Reg no to find");

                            var vehicle = gh.GetVehicle(regno);
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
