namespace ParkingLotKata2
{
    public class HelicopterCostWithdrawalStrategy : DiscountWithdrawalStrategy, IVehicleCostWithdrawalStrategy<Helicopter>
    {
        public void Execute(Helicopter vehicle, int days)
        {
            const double basePrice = 35;
            var computedPrice = basePrice * days;
            if (days >= 3)
            {
                computedPrice = Discount(days, computedPrice);
            }
            vehicle.Driver.Withdraw(computedPrice);
        }
    }
}