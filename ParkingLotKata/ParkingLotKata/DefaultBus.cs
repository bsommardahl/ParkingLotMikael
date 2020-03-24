namespace ParkingLotKata
{
    public class DefaultBus : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            vehicle.Driver.Withdraw(9);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle is Bus;
        }
    }
}