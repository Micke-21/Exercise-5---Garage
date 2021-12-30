using Exercise_5___Garage.Vehicles;

namespace Exercise_5___Garage
{
    /// <summary>
    /// Interface Trying to get the <T> to work!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGarage<T>
    {
        int Capacity { get;/* set;*/ }
        bool IsFull { get; }
        int FreePlaces { get; }
        T[] GetAllVehicle();
        T? GetVehicleByRegNo(string regNo);
        string GetVehicleTypes();
        bool IsRegNoInGarage(string regNo);

        bool AddVehicle(T vehicle);
        bool RemoveVehicle(string regNo);

    }
}
