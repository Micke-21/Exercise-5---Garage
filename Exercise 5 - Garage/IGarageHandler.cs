using Exercise_5___Garage.Vehicles;

namespace Exercise_5___Garage
{
    public interface IGarageHandler
    {
        bool AddVehicle();
        bool AddVehicle(IUI ui, string choice);
        void CreatGarage();
        void CreatGarage(int capacity);
        bool GarageIsCreated();
        Vehicle[] GetAllVehicles();
        Vehicle? GetVehicle(string regNo);
        Vehicle? GetVehicle_2(string regNo);
        string GetVehicleTypes();
        string GetVehicleTypes_2();
        string GetVehicleTypes_3();
        bool IsGarageFull();
        bool RemoveVehicle(string regNo);


        void Test();
    }
}