namespace ParkingLotKata
{
    public interface IAddDayStrategy
    {
        void Execute(Vehicle vehicle, int days);
        bool CanExecute(Vehicle vehicle, int days);
    }
}