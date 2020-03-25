namespace ParkingLotKata
{
    public class CarSizeStrategy : IParkingLotSizeStrategy
    {
        public double Execute()
        {
            return 1;
        }

        public bool CanExecute(Vehicle vehicle)
        {
            return vehicle is Car;
        }
    }
}