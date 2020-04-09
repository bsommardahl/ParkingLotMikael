namespace ParkingLotKata2
{
    public interface IVehicleCostWithdrawalStrategyFactory
    {
        IVehicleCostCalculationStrategy<T> Create<T>(T vehicle) where T:IVehicle;
    }
}