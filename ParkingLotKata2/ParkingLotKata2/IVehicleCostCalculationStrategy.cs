namespace ParkingLotKata2
{
    public interface IVehicleCostCalculationStrategy
    {
        double Execute(IVehicle vehicle, int days);
    }

    public interface IVehicleCostCalculationStrategy<in T> : IVehicleCostCalculationStrategy where T : IVehicle
    {

    }
}