using Exercise_5___Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5___Garage
{
    public class UI : IUI
    {
        /// <summary>
        /// Shows the Start menu
        /// </summary>
        public void ShowStartMenu()
        {
            Console.WriteLine("Menu\n");
            Console.WriteLine("1. Set up Garage");
            Console.WriteLine("2. Set up Garage enter capacity");

            Console.WriteLine("Q. Quit");
        }

        /// <summary>
        /// Shows the menu
        /// </summary>
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu\n");
            Console.WriteLine("1. List all vehicles.");
            Console.WriteLine("2. List vehicle types.");
            Console.WriteLine("3. Add vehicle.");
            Console.WriteLine("4. Remove vehicle");
            Console.WriteLine("5. Find vehicle");
            Console.WriteLine(" ");

            Console.WriteLine("0. Test ");
            Console.WriteLine("Q. Quit");
        }

        /// <summary>
        /// Prints the liste of vheicle types to add
        /// </summary>
        public void ChoseVehicleToAdd()
        {
            Console.Clear();
            Console.WriteLine("Chose Vehicle Tyep\n");
            Console.WriteLine("1. Vehicel.");
            Console.WriteLine("2. Airplane.");
            Console.WriteLine("3. Boat.");
            Console.WriteLine("4. Bus.");
            Console.WriteLine("5. Car.");
            Console.WriteLine("6. Motorcycle.");

        }

        /// <summary>
        /// Get a choice from the user
        /// </summary>
        /// <returns></returns>
        public string? GetMenuChoice()
        {
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Print a list of vehicles
        /// </summary>
        /// <param name="vehicles">list of vehicles to print</param>
        public void ListAllVehicles(IEnumerable<Vehicle> vehicles)
        {
            Console.Clear();
            Console.WriteLine("List of vehicles.\n");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        /// <summary>
        /// Get a string input from user
        /// </summary>
        /// <param name="message">Message to print</param>
        /// <returns>Returns the string entered</returns>
        public string? GetStringInput(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Wait for the user to press a kye
        /// </summary>
        /// <param name="message">Message to print.</param>
        /// <returns>Returns the key pressed.</returns>
        public char GetKey(string message)
        {
            Console.Write($"{message} ");
            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Print a Vehicle
        /// </summary>
        /// <param name="vehicle">Vehicle to print</param>
        public void PrintVehicle(Vehicle vehicle)
        {
            Console.Clear();
            Console.WriteLine("Vehicle.\n");
            if (vehicle == null)
                Console.WriteLine("No vehicle fond:");
            else
                Console.WriteLine($"{vehicle}");
        }



        public void PrintString(string message, bool clear = true)
        {
            if (clear)
                Console.Clear();
            Console.WriteLine(message);
        }
    }
}
