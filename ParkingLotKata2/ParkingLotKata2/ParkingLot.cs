using System;
using System.Collections.Generic;
using System.Linq;

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


        public void UnparkVehicle<T>(T vehicle, int days) where T : IVehicle
        {
            if (!_vehicles.Contains(vehicle))
                throw new UnknownVehicleException();

            var amount = GetTheAmount(vehicle, days);
            var discountedAmount = _longTermDiscounter.Discount(days, amount);
            vehicle.Driver.Withdraw(discountedAmount);

            _vehicles.Remove(vehicle);
        }

        double GetTheAmount<T>(T vehicle, int days) where T : IVehicle
        {
            var strategy = _vehicleCostWithdrawalStrategyFactory.Create(vehicle);
            var amount = strategy.Execute(vehicle, days);
            return amount;
        }
    }
}