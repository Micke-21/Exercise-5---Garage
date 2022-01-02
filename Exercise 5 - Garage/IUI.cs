using Exercise_5___Garage.Vehicles;

namespace Exercise_5___Garage
{
    public interface IUI
    {
        char GetKey(string message);
        string? GetMenuChoice();
        string? GetStringInput(string message);
        void ListAllVehicles(IEnumerable<Vehicle> vehicles);
        void PrintVehicle(Vehicle vehicle);
        void PrintString(string message, bool clear = true);   
        void ShowMenu();
        void ShowStartMenu();
        void ChoseVehicleToAdd();
    }
}