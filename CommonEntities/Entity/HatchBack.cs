using ParkingAppCommon.Interfaces;

namespace ParkingAppCommon
{
    public class HatchBack : IVehicle
    {
        public string Model { get; set; }
        public string VehicleNumber { get; set; }

        public HatchBack(string _model, string _vehicleNumber)
        {
            Model = _model;
            VehicleNumber = _vehicleNumber;
        }
    }
}