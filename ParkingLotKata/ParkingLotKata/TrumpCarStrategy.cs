namespace ParkingLotKata
{
    public class TrumpCarStrategy : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            vehicle.Driver.Withdraw(10);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle.TrumpSticker;
        }
    }
}