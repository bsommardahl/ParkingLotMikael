namespace ParkingLotKata2
{
    public class Bus : Vehicle
    {
        public Bus(IDriver driver) : base(driver)
        {
        }

        public override double Length => 4;
    }
}