namespace ParkingLotKata
{
    public class LongTermBusStrategy : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            var amount = 9 * days * 0.80;
            vehicle.Driver.Withdraw(amount);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle is Bus && days >= 3;
        }
    }
}