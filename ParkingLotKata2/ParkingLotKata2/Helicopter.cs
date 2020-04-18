namespace ParkingLotKata2
{
    public class Helicopter : Vehicle
    {
        public Helicopter(IDriver driver, string license) : base(driver, license)
        {
        }

        public override double Length => 8;
    }
}