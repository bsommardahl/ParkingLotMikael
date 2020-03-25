namespace ParkingLotKata
{
    public class BusStrategy : IAddDayStrategy<Bus>
    {
        public void Execute(Bus vehicle, int days)
        {
            var basePrice = 9.0;
            var charging = basePrice;
            if (vehicle.Motor == MotorType.Electric)
            {
                charging = basePrice * .5;
            }
            else if (days >= 3)
            {
                charging = basePrice * days * 0.80;
            }
            vehicle.Driver.Withdraw(charging);
        }
    }
}