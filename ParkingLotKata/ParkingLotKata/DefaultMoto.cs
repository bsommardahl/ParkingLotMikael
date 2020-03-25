namespace ParkingLotKata
{
    public class DefaultMoto : IAddDayStrategy<Motorcycle>
    {
        public void Execute(Motorcycle vehicle, int days)
        {
            vehicle.Driver.Withdraw(3);
        }

        
    }
}