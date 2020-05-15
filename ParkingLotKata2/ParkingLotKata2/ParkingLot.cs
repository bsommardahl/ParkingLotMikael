using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLotKata2
{
    public class ParkingLot
    {
        readonly ILongTermDiscounter _longTermDiscounter;
        readonly IVehicleCostWithdrawalStrategyFactory _vehicleCostWithdrawalStrategyFactory;
        readonly ICalculateSpaces _calculateSpaces;
        readonly ILicenseVerifier _licenseVerifier;
        readonly IGenericRepository<Vehicle> _repository;

        readonly int _originalSpaces;

        public ParkingLot(int spaces, ILongTermDiscounter longTermDiscounter,
            IVehicleCostWithdrawalStrategyFactory vehicleCostWithdrawalStrategyFactory,
            ICalculateSpaces calculateSpaces, ILicenseVerifier licenseVerifier, IGenericRepository<Vehicle> repository)
        {
            _longTermDiscounter = longTermDiscounter;
            _vehicleCostWithdrawalStrategyFactory = vehicleCostWithdrawalStrategyFactory;
            _originalSpaces = spaces;
            _calculateSpaces = calculateSpaces;
            _licenseVerifier = licenseVerifier;
            _repository = repository;

            var task = Task.Run(async () =>
            {
                for (;;)
                {
                    await Task.Delay(5000);
                    await RobotCheckOneVehicle();
                }
            });
        }

        public event EventHandler<RobotCheckEventArgType> VehicleChecked;

        async Task RobotCheckOneVehicle()
        {
            if (VehicleChecked == null) return;

            var vehicles = (await _repository.Get()).ToArray();
            if (!vehicles.Any()) return;

            try
            {
                var randomGenerator = new Random(DateTime.Now.Millisecond);
                var next = randomGenerator.Next(0, vehicles.Count());
                var vehicle = vehicles.ToArray()[next];
                var amountOwed = randomGenerator.Next(10, 30);
                throw new Exception("testing Rx exception handling.");
                VehicleChecked(this, new RobotCheckEventArgType(vehicle, amountOwed));
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw;
            }
        }

        async Task<double> GetAvailableSpaces()
        {
            var vehicles = await _repository.Get();
            var occupiedSpaces = vehicles.Select(x => _calculateSpaces.GetSpaces(x)).Sum();
            return _originalSpaces - occupiedSpaces;
        }

        public async Task ParkVehicle(Vehicle vehicle)
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
                throw new NotEnoughMoneyException("The driver do not have enough money");
            vehicle.Driver.Withdraw(discountedAmount);

            await _repository.Remove(vehicle);
        }

        double GetTheAmount<T>(T vehicle, int days) where T : Vehicle
        {
            var strategy = _vehicleCostWithdrawalStrategyFactory.Create(vehicle);
            var amount = strategy(vehicle, days);
            return amount;
        }
    }

    public class RobotCheckEventArgType
    {
        public Vehicle Vehicle { get; }
        public int AmountOwed { get; }

        public RobotCheckEventArgType(Vehicle vehicle, int amountOwed)
        {
            Vehicle = vehicle;
            AmountOwed = amountOwed;
        }
    }
}