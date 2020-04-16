using System.Reflection.Metadata.Ecma335;

namespace ParkingLotKata2
{
    public class BusCostCalculationStrategy : LongTermDiscounter, IVehicleCostCalculationStrategy<Bus>
    {
        public double Execute(Bus vehicle, int days)
        {
            const double basePrice = 9;
            var computedPrice = basePrice * days;


            return computedPrice;
        }
    }
}