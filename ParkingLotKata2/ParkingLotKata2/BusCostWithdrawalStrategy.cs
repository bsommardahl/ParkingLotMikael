using System.Reflection.Metadata.Ecma335;

namespace ParkingLotKata2
{
    public class BusCostWithdrawalStrategy : LongTermDiscounter, IVehicleCostWithdrawalStrategy<Bus>
    {
        public double Execute(Bus vehicle, int days)
        {
            const double basePrice = 9;
            var computedPrice = basePrice * days;


            return computedPrice;
        }

    }
}