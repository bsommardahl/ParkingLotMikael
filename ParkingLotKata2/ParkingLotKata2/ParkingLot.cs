using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ParkingLotKata2
{
    public class ParkingLot
    {
        readonly ILongTermDiscounter _longTermDiscounter;
        readonly IVehicleCostWithdrawalStrategyFactory _vehicleCostWithdrawalStrategyFactory;
        readonly ICalculateSpaces _calculateSpaces;
        readonly ILicenseVerifier _licenseVerifier;
        readonly List<IVehicle> _vehicles;
        readonly int _originalSpaces;


        public ParkingLot(int spaces, ILongTermDiscounter longTermDiscounter,
            IVehicleCostWithdrawalStrategyFactory vehicleCostWithdrawalStrategyFactory,
            ICalculateSpaces calculateSpaces, ILicenseVerifier licenseVerifier)
        {
            _longTermDiscounter = longTermDiscounter;
            _vehicleCostWithdrawalStrategyFactory = vehicleCostWithdrawalStrategyFactory;
            _originalSpaces = spaces;
            _calculateSpaces = calculateSpaces;
            _licenseVerifier = licenseVerifier;
            _vehicles = new List<IVehicle>();
        }

        public double Spaces => GetAvailableSpaces();

        double GetAvailableSpaces()
        {
            return _originalSpaces - _vehicles.Select(x => _calculateSpaces.GetSpaces(x)).Sum();
        }

        public void ParkVehicle(IVehicle vehicle)
        {
            if (vehicle.Length < 1) throw new VehicleHasNoLengthException();
            if (_licenseVerifier.IsInvalid(vehicle.License)) throw new InvalidLicenseException();

            var noMoreSpaces = Spaces == 0;

            var vehicleBiggerThanSpacesLeft = _calculateSpaces.GetSpaces(vehicle) > Spaces;
            if (noMoreSpaces || vehicleBiggerThanSpacesLeft)
                throw new NoMoreSpaceException();

            _vehicles.Add(vehicle);
        }


        public void UnparkVehicle(string license, int days)
        {
            var matches = _vehicles.Where(x => x.License == license).ToList();
            if (!matches.Any())
                throw new UnknownVehicleException();
            var vehicle = matches.First();
            var amount = GetTheAmount(vehicle, days);
            var discountedAmount = _longTermDiscounter.Discount(days, amount);
            if (discountedAmount > vehicle.Driver.GetWalletSum())
            {
                throw new NotEnoughMoneyException("The driver do not have enough money");
            }
            vehicle.Driver.Withdraw(discountedAmount);

            _vehicles.Remove(vehicle);
        }

        private double GetTheAmount<T>(T vehicle, int days) where T : IVehicle
        {
            var strategy = _vehicleCostWithdrawalStrategyFactory.Create(vehicle);
            var amount = strategy(vehicle, days);
            return amount;
        }


    }
}