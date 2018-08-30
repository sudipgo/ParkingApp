using ParkingAppCommon.Interfaces;

namespace ParkingAppCommon
{
    public class MiniTruck : IVehicle
    {
        public string Model { get; set; }
        public string VehicleNumber { get; set; }

        public MiniTruck(string _model, string _vehicleNumber)
        {
            Model = _model;
            VehicleNumber = _vehicleNumber;
        }
    }
}