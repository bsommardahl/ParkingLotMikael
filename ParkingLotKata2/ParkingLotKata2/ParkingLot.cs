namespace ParkingLotKata2
{
    public class ParkingLot
    {
        readonly int _metersPerSpace;


        public ParkingLot(int spaces, int metersPerSpace)
        {
            _metersPerSpace = metersPerSpace;
            Spaces = spaces;
        }

        public int Spaces { get; private set; }

        public void RemoveSpaces(int spaces)
        {
            Spaces -= spaces;
        }

        public void ParkVehicle(IVehicle vehicle)
        {
            if (Spaces == 0 || vehicle.Length < 1 || _metersPerSpace / vehicle.Length > Spaces)
                throw new NoMoreSpaceException();

            RemoveSpaces(_metersPerSpace / vehicle.Length);
        }
    }
}