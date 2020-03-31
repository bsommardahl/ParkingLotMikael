namespace ParkingLotKata2
{
    public class MotorCycleCostWithdrawalStrategy : DiscountWithdrawalStrategy, IVehicleCostWithdrawalStrategy<MotorCycle>
    {
        public void Execute(MotorCycle vehicle, int days)
        {
            const double basePrice = .5;
            var computedPrice = basePrice * days;

            if (days >= 3)
            {
                computedPrice = Discount(days, computedPrice);
            }
            vehicle.Driver.Withdraw(computedPrice);

        }
    }
}