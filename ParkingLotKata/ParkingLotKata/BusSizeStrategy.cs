namespace ParkingLotKata
{
    public class BusSizeStrategy : IParkingLotSizeStrategy
    {
        public double Execute()
        {
            return 2;
        }

        public bool CanExecute(Vehicle vehicle)
        {
            return vehicle is Bus;
        }
    }
}