namespace ParkingLotKata2
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(IDriver driver, string license)
        {
            Driver = driver;
            License = license;
        }

        public IDriver Driver { get; }
        public abstract double Length { get; }
        public string License { get; }
    }
}