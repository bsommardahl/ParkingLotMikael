namespace ParkingLotKata2
{
    public class Helicopter : Vehicle
    {
        public Helicopter(IDriver driver) : base(driver)
        {

        }
        
        public override double Length => 8;
    }
}