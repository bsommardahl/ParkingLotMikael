namespace ParkingLotKata2
{
    public class ParkingLot
    {
        readonly int _metersPerSpace;


        public ParkingLot(double spaces, int metersPerSpace)
        {
            _metersPerSpace = metersPerSpace;
            Spaces = spaces;
        }

        public double Spaces { get; private set; }

        public void RemoveSpaces(double spaces)
        {
            Spaces -= spaces;
        }

        public void ParkVehicle(IVehicle vehicle)
        {
            if (Spaces == 0 || vehicle.Length < 1 || vehicle.Length / _metersPerSpace > Spaces)
                throw new NoMoreSpaceException();

            RemoveSpaces(vehicle.Length / _metersPerSpace);
        }
    }
}