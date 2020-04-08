namespace ParkingLotKata2
{
    public class ParkingLot
    {
        readonly int _metersPerSpace;
        readonly ILongTermDiscounter _longTermDiscounter;
        readonly IVehicleCostWithdrawalStrategyFactory _vehicleCostWithdrawalStrategyFactory;
        private readonly ICalculateSpaces _calculateSpaces;


        public ParkingLot(int spaces, int metersPerSpace, ILongTermDiscounter longTermDiscounter,
            IVehicleCostWithdrawalStrategyFactory vehicleCostWithdrawalStrategyFactory,
            ICalculateSpaces calculateSpaces)
        {
            _metersPerSpace = metersPerSpace;
            _longTermDiscounter = longTermDiscounter;
            _vehicleCostWithdrawalStrategyFactory = vehicleCostWithdrawalStrategyFactory;
            Spaces = spaces;
            _calculateSpaces = calculateSpaces;
        }

        public double Spaces { get; private set; }

        public void ParkVehicle(IVehicle vehicle)
        {
            var noMoreSpaces = Spaces == 0;

            var vehicleToSmall = vehicle.Length < 1;
            var VehicleBiggerThanSpacesLeft = _calculateSpaces.GetSpaces(vehicle) > Spaces;
            if (noMoreSpaces || vehicleToSmall || VehicleBiggerThanSpacesLeft)
                throw new NoMoreSpaceException();

            Spaces -= _calculateSpaces.GetSpaces(vehicle);
        }


        public void UnparkVehicle(IVehicle vehicle, int days)
        {
            Spaces += _calculateSpaces.GetSpaces(vehicle);

            var amount = GetTheAmount(vehicle, days);
            var discountedAmount = _longTermDiscounter.Discount(days, amount);
            vehicle.Driver.Withdraw(discountedAmount);

        }

        private double GetTheAmount(IVehicle vehicle, int days)
        {
            var strategy = _vehicleCostWithdrawalStrategyFactory.Create(vehicle);
            var amount = strategy.Execute(vehicle, days);
            return amount;
        }
    }
}