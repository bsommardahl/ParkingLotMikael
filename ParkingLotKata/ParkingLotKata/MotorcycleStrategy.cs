namespace ParkingLotKata
{
    public class MotorcycleStrategy : IAddDayStrategy<Motorcycle>
    {
        public void Execute(Motorcycle vehicle, int days)
        {
            vehicle.Driver.Withdraw(3);
        }

        
    }
}