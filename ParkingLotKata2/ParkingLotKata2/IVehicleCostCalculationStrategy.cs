namespace ParkingLotKata2
{
    public interface VehicleCostCalculationStrategy
    {

    }

    public interface VehicleCostCalculationStrategy<in T> : VehicleCostCalculationStrategy where T : Vehicle
    {
        double Execute(T vehicle, int days);
    }
}