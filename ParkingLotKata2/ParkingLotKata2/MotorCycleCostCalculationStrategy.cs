namespace ParkingLotKata2
{
    public class MotorCycleCostCalculationStrategy : VehicleCostCalculationStrategy<MotorCycle>
    {
        public double Execute(MotorCycle vehicle, int days)
        {
            const double basePrice = .5;
            var computedPrice = basePrice * days;


            return computedPrice;
        }
    }
}