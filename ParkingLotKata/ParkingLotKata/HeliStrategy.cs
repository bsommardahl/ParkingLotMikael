namespace ParkingLotKata
{
    public class HeliStrategy : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            vehicle.Driver.Withdraw(70);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle is Helicopter && days > 1;
        }
    }
}