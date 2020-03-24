namespace ParkingLotKata
{
    public class ElectricCarStrategy : IAddDayStrategy
    {
        public void Execute(Vehicle vehicle, int days)
        {
            vehicle.Driver.Withdraw(2.50);
        }

        public bool CanExecute(Vehicle vehicle, int days)
        {
            return vehicle.Motor == MotorType.Electric && vehicle is Car;
        }
    }
}