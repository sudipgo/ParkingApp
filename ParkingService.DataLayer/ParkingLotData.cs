using System;
using System.Collections.Generic;
using System.Linq;
using ParkingAppCommon;
using ParkingAppCommon.Constants;

namespace ParkingService.DataLayer
{
    public class ParkingLotData
    {
        public static IEnumerable<ParkingSpot> ParkingSpots { get; set; }

        static ParkingLotData()
        {
            ParkingSpots = new List<ParkingSpot>
            {
                new ParkingSpot{ParkingSpotNumber=1,IsFree=true,Size=VehicleTypeConstant.HatchBack},
                new ParkingSpot{ParkingSpotNumber=2,IsFree=true,Size=VehicleTypeConstant.HatchBack},
                new ParkingSpot{ParkingSpotNumber=3,IsFree=false,Size=VehicleTypeConstant.HatchBack},
                new ParkingSpot{ParkingSpotNumber=4,IsFree=true,Size=VehicleTypeConstant.Seden},
                new ParkingSpot{ParkingSpotNumber=5,IsFree=true,Size=VehicleTypeConstant.Seden},
                new ParkingSpot{ParkingSpotNumber=6,IsFree=false,Size=VehicleTypeConstant.Seden},
                new ParkingSpot{ParkingSpotNumber=7,IsFree=true,Size=VehicleTypeConstant.MiniTruck},
                new ParkingSpot{ParkingSpotNumber=8,IsFree=true,Size=VehicleTypeConstant.MiniTruck},
                new ParkingSpot{ParkingSpotNumber=9,IsFree=true,Size=VehicleTypeConstant.MiniTruck},
                new ParkingSpot{ParkingSpotNumber=10,IsFree=false,Size=VehicleTypeConstant.MiniTruck},
            };

            AssignPrice(ParkingSpots);
            AssignExitTime(ParkingSpots);
        }

        public static void UpdateParkingSpot(ParkingSpot parkingSpot)
        {
            var _parkingSpot=ParkingSpots.FirstOrDefault(a=>a.ParkingSpotNumber==parkingSpot.ParkingSpotNumber);
            _parkingSpot.IsFree = false;
            _parkingSpot.ExitTimeFromSpot = DateTime.Now.Add(TimeSpan.FromMinutes(10)).ToString("MM/dd/yyyy hh:mm tt");
        }

        private static void AssignExitTime(IEnumerable<ParkingSpot> parkingSpots)
        {
            foreach (var spot in parkingSpots)
            {
                if (!spot.IsFree)
                {
                    spot.ExitTimeFromSpot = DateTime.Now.Add(TimeSpan.FromMinutes(10)).ToString("MM/dd/yyyy hh:mm tt");
                }
            }
        }

        private static void AssignPrice(IEnumerable<ParkingSpot> parkingSpots)
        {
            foreach (var spot in parkingSpots)
            {
                if (spot.Size == VehicleTypeConstant.HatchBack)
                {
                    spot.Price = 10;
                }
                else if (spot.Size == VehicleTypeConstant.Seden)
                {
                    spot.Price = 20;
                }
                else if (spot.Size == VehicleTypeConstant.MiniTruck)
                {
                    spot.Price = 30;
                }
            }
        }
    }
}