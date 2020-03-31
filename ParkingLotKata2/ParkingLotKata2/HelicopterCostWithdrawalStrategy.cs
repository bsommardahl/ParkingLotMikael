namespace ParkingLotKata2
{
    public class HelicopterCostWithdrawalStrategy : IVehicleCostWithdrawalStrategy<Helicopter>
    {
        public void Execute(Helicopter vehicle, int days)
        {
            const double basePrice = 35;
            var computedPrice = basePrice * days;
            
            vehicle.Driver.Withdraw(computedPrice);
        }
    }
}