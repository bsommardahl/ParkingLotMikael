namespace ParkingLotKata2
{
    public class ParkingLot
    {
        readonly int _metersPerSpace;
        readonly ILongTermDiscounter _longTermDiscounter;
        readonly IVehicleCostWithdrawalStrategyFactory _vehicleCostWithdrawalStrategyFactory;


        public ParkingLot(int spaces, int metersPerSpace, ILongTermDiscounter longTermDiscounter,
            IVehicleCostWithdrawalStrategyFactory vehicleCostWithdrawalStrategyFactory)
        {
            _metersPerSpace = metersPerSpace;
            _longTermDiscounter = longTermDiscounter;
            _vehicleCostWithdrawalStrategyFactory = vehicleCostWithdrawalStrategyFactory;
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
            var factory = _vehicleCostWithdrawalStrategyFactory.Create(vehicle);
            factory.Execute(vehicle, days);
            //apply discount
            ////charge the driver

        }
    }
}