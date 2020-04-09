namespace ParkingLotKata2
{
    public class HelicopterCostCalculationStrategy : IVehicleCostCalculationStrategy<Helicopter>
    {
        public double Execute(Helicopter vehicle, int days)
        {
            const double basePrice = 35;
            var computedPrice = basePrice * days;

            return computedPrice;
        }
    }
}