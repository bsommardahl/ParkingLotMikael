namespace ParkingLotKata
{
    public class DefaultMoto : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            vehicle.Driver.Withdraw(3);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle is Motorcycle;
        }
    }
}