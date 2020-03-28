namespace ParkingLotKata
{
    public class HelicopterStrategy : IAddDayStrategy<Helicopter>
    {

        public void Execute(Helicopter vehicle, int days)
        {
            const int basePrice = 35;
            var charging = basePrice;
            if (days > 1)
            {
                charging = basePrice * 2;
            }
            vehicle.Driver.Withdraw(charging);
        }
    }
}