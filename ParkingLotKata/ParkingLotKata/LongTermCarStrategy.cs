namespace ParkingLotKata
{
    public class LongTermCarStrategy : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            var amount = 5 * days * 0.70;
            vehicle.Driver.Withdraw(amount);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle is Car && days >= 6;
        }
    }
}