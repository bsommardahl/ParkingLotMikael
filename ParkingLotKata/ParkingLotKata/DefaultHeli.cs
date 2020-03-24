namespace ParkingLotKata
{
    public class DefaultHeli : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            vehicle.Driver.Withdraw(35);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle is Helicopter;
        }
    }
}