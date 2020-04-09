namespace ParkingLotKata2
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(IDriver driver)
        {
            Driver = driver;
        }

        public IDriver Driver { get; }
        public abstract double Length { get; }

    }
}