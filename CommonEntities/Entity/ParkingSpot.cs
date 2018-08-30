using System;

namespace ParkingAppCommon
{
    public class ParkingSpot
    { 
        public int ParkingSpotNumber { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public bool IsFree { get; set; }
        public string ExitTimeFromSpot { get; set; }
    }
}