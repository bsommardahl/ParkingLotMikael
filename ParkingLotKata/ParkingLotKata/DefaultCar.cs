namespace ParkingLotKata
{
    public class DefaultCar : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            vehicle.Driver.Withdraw(5);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle is Car;
        }
    }
}