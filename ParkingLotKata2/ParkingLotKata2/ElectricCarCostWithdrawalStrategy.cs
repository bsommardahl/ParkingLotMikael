namespace ParkingLotKata2
{
    public class ElectricCarCostWithdrawalStrategy : DiscountWithdrawalStrategy, IVehicleCostWithdrawalStrategy<ElectricCar>
    {

        public void Execute(ElectricCar vehicle, int days)
        {
            const double basePrice = 2.50;
            var computedPrice = basePrice * days;

            if (days >= 3)
            {
                computedPrice = Discount(days, computedPrice);
            }
            vehicle.Driver.Withdraw(computedPrice);
        }
    }
}