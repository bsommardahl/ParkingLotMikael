namespace ParkingLotKata2
{
    public class ElectricCar : Vehicle
    {
        public ElectricCar(IDriver driver, string license) : base(driver, license)
        {
        }

        public override double Length => 2;
    }
}