using Exercise_5___Garage.Vehicles;

namespace Exercise_5___Garage
{
    public interface IGarage<T>
    {
        int Capacity { get;/* set;*/ }
        bool IsFull { get; }
        int FreePlaces { get; }
        Vehicle[] GetAllVehicle();
        Vehicle? GetVehicleByRegNo(string regNo);
        string GetVehicleTypes();
        bool IsRegNoFound(string regNo);

        bool AddVehicle(Vehicle vehicle);
        bool RemoveVehicle(string regNo);

        void SeedVehicles();
    }

    /// <summary>
    /// Interface Trying to get the <T> to work!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGarage2<T>
    {
        int Capacity { get;/* set;*/ }
        bool IsFull { get; }
        int FreePlaces { get; }
        T[] GetAllVehicle();
        T? GetVehicleByRegNo(string regNo);
        string GetVehicleTypes();
        bool IsRegNoFound(string regNo);

        bool AddVehicle(T vehicle);
        bool RemoveVehicle(string regNo);

    }
}
