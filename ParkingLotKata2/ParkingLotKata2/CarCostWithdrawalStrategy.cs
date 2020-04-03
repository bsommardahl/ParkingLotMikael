namespace ParkingLotKata2
{
    public class CarCostWithdrawalStrategy : LongTermDiscounter, IVehicleCostWithdrawalStrategy<Car>
    {
        public void Execute(Car vehicle, int days)
        {
            const double basePrice = 5;
            var computedPrice = basePrice * days;
            if (vehicle.HasTrumpSticker)
            {
                computedPrice = basePrice * 2;
            }
           
            vehicle.Driver.Withdraw(computedPrice);
        }
    }
}