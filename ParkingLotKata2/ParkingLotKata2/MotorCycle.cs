namespace ParkingLotKata2
{
    public class MotorCycle : Vehicle
    {
        public MotorCycle(IDriver driver) : base(driver)
        {

        }
        
        public override double Length => 1;
    }
}