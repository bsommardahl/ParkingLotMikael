using System;

namespace ParkingLotKata2
{
    public interface IVehicleCostWithdrawalStrategyFactory
    {
        Func<T, int, double> Create<T>(T vehicle) where T: IVehicle;
    }
}