using System.Collections.Generic;
using ParkingAppCommon;
using ParkingAppCommon.Interfaces;

namespace Parking.Service
{
    public interface IParkingService
    {
        IEnumerable<ParkingSpot> ParkingSpot { get; set; }

        string Park(IVehicle vehicle);
    }
}