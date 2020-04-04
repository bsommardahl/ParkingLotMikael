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