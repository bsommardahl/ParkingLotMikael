namespace ParkingLotKata2
{
    public class ElectricCarCostCalculationStrategy : IVehicleCostCalculationStrategy<ElectricCar>
    {

        public double Execute(ElectricCar vehicle, int days)
        {
            const double basePrice = 2.50;
            var computedPrice = basePrice * days;


            return computedPrice;
        }
    }
}