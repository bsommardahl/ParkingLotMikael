using System;

namespace ParkingLotKata2
{
    public class NoMatchingVehicleCostWithdrawalStrategyException : Exception
    {
        public NoMatchingVehicleCostWithdrawalStrategyException(Vehicle vehicle) : base(
            $"There were no matching strategies found for the vehicle type {vehicle.GetType()}.")
        {
        }
    }
}