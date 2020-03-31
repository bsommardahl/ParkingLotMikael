namespace ParkingLotKata2
{
    public class Vehicle : IVehicle
    {
        public Vehicle(IDriver driver)
        {
            Driver = driver;
        }

        public IDriver Driver { get; }
        public double Length { get; }

    }
}