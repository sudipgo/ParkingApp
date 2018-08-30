using Parking.Service;
using ParkingAppCommon.Interfaces;
using VehicleHandler.Factory;

namespace Parking.ServiceCaller
{
    public class ServiceCaller
    {
        private IParkingService _service;

        public ServiceCaller() : this(new ParkingService())
        {
        }

        public ServiceCaller(IParkingService service)
        {
            _service = service;
        }

        public string Park(string type, string model, string number)
        {
            IVehicle vehicle = VehicleFactory.GetVehicleType(type, model, number);
            return _service.Park(vehicle);
        }
    }
}