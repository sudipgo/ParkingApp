using System;
using System.Collections.Generic;
using ParkingAppCommon;
using ParkingAppCommon.Interfaces;
using ParkingService.BuisnessLayer;

namespace Parking.Service
{
    public class ParkingService : IParkingService
    {
        private IFacade facade;
        public IEnumerable<ParkingSpot> ParkingSpot { get; set; }

        public ParkingService() : this(new Facade())
        {
        }

        public ParkingService(IFacade _facade)
        {
            facade = _facade;
        }

        public string Park(IVehicle vehicle)
        {
            if (facade.IsAnyCarExitingFromParkingLot())
            {
                return "Wait for some time...";
            }

            var parkingSpot = facade.GetParkingSpotIfAvailable(vehicle);

            if (parkingSpot == null)
            {
                return "No Parking Spot Available";
            }

            return $"Vehicle Number:{vehicle.VehicleNumber}{Environment.NewLine}" +
                   $"Parking Spot Number:{parkingSpot.ParkingSpotNumber}{Environment.NewLine}"+
                   $"Parking Charge:{parkingSpot.Price}{Environment.NewLine}"+
                   $"Exit Time:{parkingSpot.ExitTimeFromSpot}";
        }
    }
}