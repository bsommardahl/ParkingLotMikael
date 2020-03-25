namespace ParkingLotKata
{
    public interface IParkingLotSizeStrategy
    {
        double Execute();
        bool CanExecute(Vehicle vehicle);
    }
}