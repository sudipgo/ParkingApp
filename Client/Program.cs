using System;
using Parking.ServiceCaller;
using ParkingAppCommon.Constants;

namespace Client
{
    public class Program
    {
        private static void Main(string[] args)
        {
            ServiceCaller caller = new ServiceCaller();
            int capacity = 0;
            while (capacity < 10)
            {
                Console.WriteLine();
                Console.WriteLine("Select Car type");
                Console.WriteLine("1:Hatchback");
                Console.WriteLine("2:Seden");
                Console.WriteLine("3:MiniTruck");
                int type = Convert.ToInt32(Console.ReadLine());
                string vehicleType = GetVehicleType(type);
                Console.WriteLine("Enter Model");
                string model = Console.ReadLine();
                Console.WriteLine("Enter vehicle number");
                string vehiclenumber = Console.ReadLine();
                Console.WriteLine();
                var parkingDetails = caller.Park(vehicleType, model, vehiclenumber);
                Console.WriteLine(parkingDetails);
                Console.WriteLine();
                capacity++;
            }

            Console.ReadLine();
        }

        private static string GetVehicleType(int type)
        {
            switch (type)
            {
                case 1:
                    return VehicleTypeConstant.HatchBack;

                case 2:
                    return VehicleTypeConstant.Seden;

                case 3:
                    return VehicleTypeConstant.MiniTruck;

                default:
                    throw new Exception();
            }
        }
    }
}