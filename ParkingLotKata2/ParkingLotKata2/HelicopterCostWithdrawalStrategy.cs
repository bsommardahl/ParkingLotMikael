namespace ParkingLotKata2
{
    public class HelicopterCostWithdrawalStrategy : IVehicleCostWithdrawalStrategy<Helicopter>
    {
        public double Execute(Helicopter vehicle, int days)
        {
            const double basePrice = 35;
            var computedPrice = basePrice * days;

            return computedPrice;
        }
    }
}