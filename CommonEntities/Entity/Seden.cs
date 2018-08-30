using ParkingAppCommon.Interfaces;

namespace ParkingAppCommon
{
    public class Seden : IVehicle
    {
        public string Model { get; set; }
        public string VehicleNumber { get; set; }

        public Seden(string _model, string _vehicleNumber)
        {
            Model = _model;
            VehicleNumber = _vehicleNumber;
        }
    }
}