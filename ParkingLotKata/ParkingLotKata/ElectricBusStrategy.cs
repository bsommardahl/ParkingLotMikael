namespace ParkingLotKata
{
    public class ElectricBusStrategy : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            vehicle.Driver.Withdraw(4.50);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle.Motor == MotorType.Electric && vehicle is Bus;
        }
    }
}