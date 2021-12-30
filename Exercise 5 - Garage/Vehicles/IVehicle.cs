namespace Exercise_5___Garage.Vehicles
{
    public interface IVehicle
    {
        string? Make { get; set; }
        string? Model { get; set; }
        string? Color { get; set; }

        string RegNo
        {
            get;
            //private set;
        }
        int NoOfWheel { get; set; }
    }
}