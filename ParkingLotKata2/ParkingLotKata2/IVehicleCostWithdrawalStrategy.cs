namespace ParkingLotKata2
{
    public interface IVehicleCostCalculationStrategy
    {
    }
    public interface IVehicleCostWithdrawalStrategy<in T> : IVehicleCostCalculationStrategy where T : Vehicle
    {
        void Execute(T vehicle);
    }

}