namespace ParkingLotKata2
{
    public interface IVehicleCostWithdrawalStrategyFactory
    {
        IVehicleCostCalculationStrategy Create(Vehicle vehicle);
    }
}