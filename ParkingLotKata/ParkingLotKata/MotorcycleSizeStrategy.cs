namespace ParkingLotKata
{
    public class MotorcycleSizeStrategy : IParkingLotSizeStrategy
    {
        public double Execute()
        {
            return .5;
        }

        public bool CanExecute(Vehicle vehicle)
        {
            return vehicle is Motorcycle;
        }
    }
}