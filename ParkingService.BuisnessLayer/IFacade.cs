using System.Collections.Generic;
using ParkingAppCommon;
using ParkingAppCommon.Interfaces;

namespace ParkingService.BuisnessLayer
{
    public interface IFacade
    {
        IEnumerable<ParkingSpot> ParkingSpot { get; set; }

        ParkingSpot GetParkingSpotIfAvailable(IVehicle vehicle);
        bool IsAnyCarExitingFromParkingLot();
    }
}