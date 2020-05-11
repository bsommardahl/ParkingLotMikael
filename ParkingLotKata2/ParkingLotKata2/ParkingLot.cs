using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotKata2
{
    public class ParkingLot
    {
        readonly ILongTermDiscounter _longTermDiscounter;
        readonly IVehicleCostWithdrawalStrategyFactory _vehicleCostWithdrawalStrategyFactory;
        readonly ICalculateSpaces _calculateSpaces;
        readonly ILicenseVerifier _licenseVerifier;
        private readonly IGenericRepository<IVehicle> _repository;

        readonly int _originalSpaces;

        public ParkingLot(int spaces, ILongTermDiscounter longTermDiscounter,
            IVehicleCostWithdrawalStrategyFactory vehicleCostWithdrawalStrategyFactory,
            ICalculateSpaces calculateSpaces, ILicenseVerifier licenseVerifier, IGenericRepository<IVehicle> repository)
        {
            _longTermDiscounter = longTermDiscounter;
            _vehicleCostWithdrawalStrategyFactory = vehicleCostWithdrawalStrategyFactory;
            _originalSpaces = spaces;
            _calculateSpaces = calculateSpaces;
            _licenseVerifier = licenseVerifier;
            _repository = repository;


            //var task = Task.Run(async () =>
            //{
            //    for (; ; )
            //    {
            //        await Task.Delay(5000);
            //        Console.WriteLine("Send the auto-bot.");


            //    }
            //});
        }

        async Task<double> GetAvailableSpaces()
        {
            var vehicles = await _repository.Get();
            var occupiedSpaces = vehicles.Select(x => _calculateSpaces.GetSpaces(x)).Sum();
            return _originalSpaces - occupiedSpaces;
        }

        public async Task ParkVehicle(IVehicle vehicle)
        {
            if (vehicle.Length < 1) throw new VehicleHasNoLengthException();
            if (_licenseVerifier.IsInvalid(vehicle.License)) throw new InvalidLicenseException();

            var availableSpaces = await GetAvailableSpaces();
            var noMoreSpaces = availableSpaces == 0;

            var spacesToRemove = _calculateSpaces.GetSpaces(vehicle);
            var vehicleBiggerThanSpacesLeft = spacesToRemove > availableSpaces;
            if (noMoreSpaces || vehicleBiggerThanSpacesLeft)
                throw new NoMoreSpaceException();
            await _repository.Add(vehicle);
        }

        public async Task UnparkVehicle(string license, int days)
        {
            var vehicle = await _repository.Get(license);
            if (vehicle == null)
                throw new UnknownVehicleException();

            var amount = GetTheAmount(vehicle, days);
            var discountedAmount = _longTermDiscounter.Discount(days, amount);
            if (discountedAmount > vehicle.Driver.GetWalletSum())
            {
                throw new NotEnoughMoneyException("The driver do not have enough money");
            }
            vehicle.Driver.Withdraw(discountedAmount);

            _repository.Remove(vehicle);
        }

        private double GetTheAmount<T>(T vehicle, int days) where T : IVehicle
        {
            var strategy = _vehicleCostWithdrawalStrategyFactory.Create(vehicle);
            var amount = strategy(vehicle, days);
            return amount;
        }


    }
}