using System;
using ParkingAppCommon;
using ParkingAppCommon.Constants;
using ParkingAppCommon.Interfaces;

namespace VehicleHandler.Factory
{
    public class VehicleFactory
    {
        public static IVehicle GetVehicleType(string type, string model, string number)
        {
            switch (type)
            {
                case VehicleTypeConstant.HatchBack:
                    return new HatchBack(model, number);

                case VehicleTypeConstant.Seden:
                    return new Seden(model, number);

                case VehicleTypeConstant.MiniTruck:
                    return new MiniTruck(model, number);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}