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
        public void ShowStartMenu()
        {
            Console.WriteLine("Menu\n");
            Console.WriteLine("1. Set up Garage");

            Console.WriteLine("Q. Quit");
        }

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

        public string? GetMenuChoice()
        {
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        public void ListAllVehicles(IEnumerable<Vehicle> vehicles)
        {
            Console.Clear();
            Console.WriteLine("List of vehicles.\n");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        public string? GetStringInput(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine();
        }

        public char GetKey(string message)
        {
            Console.Write($"{message} ");
            return Console.ReadKey().KeyChar;
        }

        public void PrintVehicle(Vehicle vehicle)
        {
            Console.Clear();
            Console.WriteLine("Vehicle.\n");
            if (vehicle == null)
                Console.WriteLine("No vehicle fond:");
            Console.WriteLine($"{vehicle}");
        }

        public void PrintString(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}
