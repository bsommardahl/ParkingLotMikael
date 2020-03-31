namespace ParkingLotKata2
{
    public class CarCostWithdrawalStrategy : DiscountWithdrawalStrategy, IVehicleCostWithdrawalStrategy<Car>
    {
        public void Execute(Car vehicle, int days)
        {
            const double basePrice = 5;
            var computedPrice = basePrice * days;
            if (vehicle.HasTrumpSticker)
            {
                computedPrice = basePrice * 2;
            }
            if (days >= 3)
            {
                computedPrice = Discount(days, computedPrice);
            }
            vehicle.Driver.Withdraw(computedPrice);
        }
    }
}