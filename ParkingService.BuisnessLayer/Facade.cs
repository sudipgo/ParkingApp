using System;
using System.Collections.Generic;
using System.Linq;
using ParkingAppCommon;
using ParkingAppCommon.Interfaces;
using ParkingService.DataLayer;

namespace ParkingService.BuisnessLayer
{
    public class Facade : IFacade
    {
        public IEnumerable<ParkingSpot> ParkingSpot { get; set; }

        public Facade()
        {
            ParkingSpot = ParkingLotData.ParkingSpots;
        }

        public ParkingSpot GetParkingSpotIfAvailable(IVehicle vehicle)
        {
            IEnumerable<ParkingSpot> freeSpaceForParking = GetFreeSpacesForparking();

            if (freeSpaceForParking.Count() == 0)
            {
                return null;
            }

            var parkingSpot = AssignParkingSpotToVehicle(vehicle, freeSpaceForParking);

            if (parkingSpot==null)
            {
                return null;
            }

            ParkingLotData.UpdateParkingSpot(parkingSpot);
            return parkingSpot;
        }
        private ParkingSpot AssignParkingSpotToVehicle(IVehicle Vehicle, IEnumerable<ParkingSpot> freeSpaceForParking)
        {
            if (Vehicle is HatchBack)
            {
                return FindFreeSpotForHachBack(freeSpaceForParking);
            }
            else if (Vehicle is Seden)
            {
                return FindFreeSpotForSeden(freeSpaceForParking);
            }
            else if (Vehicle is MiniTruck)
            {
                return FindFreeSpotForMiniTruck(freeSpaceForParking);
            }
            else
            {
                return freeSpaceForParking.FirstOrDefault();
            }
        }

        private ParkingSpot FindFreeSpotForMiniTruck(IEnumerable<ParkingSpot> freeSpaceForParking)
        {
                return freeSpaceForParking.FirstOrDefault(x => x.Size == "MiniTruck");
        }

        private ParkingSpot FindFreeSpotForSeden(IEnumerable<ParkingSpot> freeSpaceForParking)
        {
            if (freeSpaceForParking.Any(x => x.Size == "Seden"))
            {
                return freeSpaceForParking.First(x => x.Size == "Seden");
            }
            else if (freeSpaceForParking.Any(x => x.Size == "MiniTruck"))
            {
                return freeSpaceForParking.First(x => x.Size == "MiniTruck");
            }
            else
            {
                return null;
            }
        }

        private ParkingSpot FindFreeSpotForHachBack(IEnumerable<ParkingSpot> freeSpaceForParking)
        {
            if (freeSpaceForParking.Any(x => x.Size == "HatchBack"))
            {
                return freeSpaceForParking.First(x => x.Size == "HatchBack");
            }
            else if (freeSpaceForParking.Any(x => x.Size == "Seden"))
            {
                return freeSpaceForParking.First(x => x.Size == "Seden");
            }
            else if (freeSpaceForParking.Any(x => x.Size == "MiniTruck"))
            {
                return freeSpaceForParking.First(x => x.Size == "MiniTruck");
            }
            else
            {
                return null;
            }
        }

        private IEnumerable<ParkingSpot> GetFreeSpacesForparking()
        {
            return ParkingSpot.Where( x => x.IsFree == true);
        }

        public bool IsAnyCarExitingFromParkingLot()
        {
            return ParkingSpot.Any(x => x.ExitTimeFromSpot == DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
        }
    }
}