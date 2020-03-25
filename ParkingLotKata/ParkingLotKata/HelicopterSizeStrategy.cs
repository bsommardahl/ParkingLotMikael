namespace ParkingLotKata
{
    public class HelicopterSizeStrategy : IParkingLotSizeStrategy
    {
        public double Execute()
        {
            return 8;
        }

        public bool CanExecute(Vehicle vehicle)
        {
            return vehicle is Helicopter;
        }
    }
}