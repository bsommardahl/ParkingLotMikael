namespace ParkingLotKata2
{
    public interface IVehicle
    {
        IDriver Driver { get; }
        double Length { get; }
    }
}