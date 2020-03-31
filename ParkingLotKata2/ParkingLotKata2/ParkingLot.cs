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

        public void ParkVehicle(IVehicle vehicle)
        {
            if (Spaces == 0 || vehicle.Length < 1 || GetSpaces(vehicle) > Spaces)
                throw new NoMoreSpaceException();

            Spaces -= GetSpaces(vehicle);
        }

        double GetSpaces(IVehicle vehicle)
        {
            return vehicle.Length / _metersPerSpace;
        }


        public void UnparkVehicle(IVehicle vehicle, int days)
        {

            Spaces += GetSpaces(vehicle);
            //increase spaces
            //charge the driver
//apply discount
        }

        
    }
}