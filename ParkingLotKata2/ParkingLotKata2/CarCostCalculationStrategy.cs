namespace ParkingLotKata2
{
    public class CarCostCalculationStrategy : LongTermDiscounter, IVehicleCostCalculationStrategy<Car>
    {
        public double Execute(Car vehicle, int days)
        {
            const double basePrice = 5;
            var computedPrice = basePrice * days;
            if (vehicle.HasTrumpSticker) computedPrice = basePrice * 2;

            return computedPrice;
        }
    }
}