namespace ParkingLotKata2
{
    public interface IVehicle
    {
        IDriver Driver { get; }
        int Length { get;  }
    }
}