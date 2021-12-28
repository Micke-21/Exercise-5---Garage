using Exercise_5___Garage.Vehicles;

namespace Exercise_5___Garage
{
    public interface IGarageHandler
    {
        bool AddVehicle();
        bool AddVehicle(IUI ui, string choice);
        void CreatGarage();
        bool GarageIsCreated();
        Vehicle[] GetAllVehicles();
        Vehicle GetVehicle(string regNo);
        string GetVehicleTypes();
        bool IsGarageFull();
        bool RemoveVehicle(string regNo);
    }
}