namespace ParkingLotKata2
{
    public class CalculateSpaces : ICalculateSpaces
    {
        readonly int _metersPerSpace;


        public CalculateSpaces(int metersPerSpace)
        {
            _metersPerSpace = metersPerSpace;
        }

        public double GetSpaces(IVehicle vehicle)
        {
            return vehicle.Length / _metersPerSpace;
        }
    }
}