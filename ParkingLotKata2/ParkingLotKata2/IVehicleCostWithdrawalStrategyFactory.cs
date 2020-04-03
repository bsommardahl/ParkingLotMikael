namespace ParkingLotKata2
{
    public interface IVehicleCostWithdrawalStrategyFactory
    {
        IVehicleCostWithdrawalStrategy<T> Create<T>(T vehicle) where T:IVehicle;
    }
}