namespace ParkingLotKata2
{
    public class MotorCycle : Vehicle
    {
        public MotorCycle(IDriver driver, string license) : base(driver, license)
        {
        }

        public override double Length => 1;
    }
}