namespace ParkingLotKata2
{
    public interface IVehicleCostCalculationStrategy
    {
    }
    public interface IVehicleCostWithdrawalStrategy<in T> : IVehicleCostCalculationStrategy where T : IVehicle
    {
        void Execute(T vehicle, int days);
    }

}