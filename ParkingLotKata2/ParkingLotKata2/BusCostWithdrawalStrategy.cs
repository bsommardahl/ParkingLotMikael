using System.Reflection.Metadata.Ecma335;

namespace ParkingLotKata2
{
    public class BusCostWithdrawalStrategy : LongTermDiscounter, IVehicleCostWithdrawalStrategy<Bus>
    {
        public void Execute(Bus vehicle, int days)
        {
            const double basePrice = 9;
            var computedPrice = basePrice * days;
           

            vehicle.Driver.Withdraw(computedPrice);
        }

    }
}