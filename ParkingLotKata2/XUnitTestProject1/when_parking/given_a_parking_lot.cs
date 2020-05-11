using FakeItEasy;
using ParkingLotKata2;
using TestProject1;

namespace XUnitTestProject1
{
    public abstract class given_a_parking_lot
    {
        protected readonly ParkingLot Sut;
        protected readonly ILongTermDiscounter _longTermDiscounter;
        protected readonly IVehicleCostWithdrawalStrategyFactory _vehicleCostWithdrawalStrategyFactory;
        protected readonly int _originalAmountOfSpaces;
        protected ICalculateSpaces _calculateSpaces;
        protected ILicenseVerifier _licenseVerifier;
        protected IGenericRepository<Vehicle> _vehicleRepository;

        protected given_a_parking_lot()
        {
            _originalAmountOfSpaces = 100;
            _longTermDiscounter = A.Fake<ILongTermDiscounter>();
            _vehicleCostWithdrawalStrategyFactory = A.Fake<IVehicleCostWithdrawalStrategyFactory>();
            _calculateSpaces = A.Fake<ICalculateSpaces>();
            _licenseVerifier = A.Fake<ILicenseVerifier>();
            _vehicleRepository = A.Fake<IGenericRepository<Vehicle>>();
            Sut = new ParkingLot(_originalAmountOfSpaces, _longTermDiscounter,
                _vehicleCostWithdrawalStrategyFactory, _calculateSpaces, _licenseVerifier, _vehicleRepository);
        }
    }
}