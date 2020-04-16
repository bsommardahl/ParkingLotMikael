using System;

namespace ParkingLotKata2
{
    public class NoMatchingVehicleCostWithdrawalStrategyException : Exception
    {
        public NoMatchingVehicleCostWithdrawalStrategyException(IVehicle vehicle) : base(
            $"There were no matching strategies found for the vehicle type {vehicle.GetType()}.")
        {
        }
    }
}