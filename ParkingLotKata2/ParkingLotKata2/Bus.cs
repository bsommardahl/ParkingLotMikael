namespace ParkingLotKata2
{
    public class Bus : Vehicle
    {
        public Bus(IDriver driver, string license) : base(driver, license)
        {
        }

        public override double Length => 4;
    }
}