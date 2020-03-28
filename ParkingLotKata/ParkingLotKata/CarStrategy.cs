namespace ParkingLotKata
{
    public class CarStrategy : IAddDayStrategy<Car>
    {
        public void Execute(Car vehicle, int days)
        {
            const int basePrice = 5;
            double charging = basePrice;
            if (vehicle.TrumpSticker)
            {
                charging = basePrice *2;
            }
            else if (vehicle.Motor == MotorType.Electric)
            {
                charging = basePrice * .5;
            }
            else if (days >= 6)
            {
                charging = basePrice * days * 0.70;
            }
            
            vehicle.Driver.Withdraw(charging);
        }
    }
}