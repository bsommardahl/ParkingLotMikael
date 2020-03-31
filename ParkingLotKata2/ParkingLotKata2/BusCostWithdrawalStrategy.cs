using System.Reflection.Metadata.Ecma335;

namespace ParkingLotKata2
{
    public class BusCostWithdrawalStrategy : DiscountWithdrawalStrategy, IVehicleCostWithdrawalStrategy<Bus>
    {
        public void Execute(Bus vehicle, int days)
        {
            const double basePrice = 9;
            var computedPrice = basePrice * days;
            if (days >= 3)
            {
                computedPrice = Discount(days, computedPrice);
            }

            vehicle.Driver.Withdraw(computedPrice);
        }

    }
}