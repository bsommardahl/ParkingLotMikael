using System.Collections.Generic;
using FluentAssertions;
using ParkingLotKata2;

namespace TestProject1
{
    public abstract class given_an_integrated_parking_lot
    {
        protected ParkingLot sut;
        protected FakeRepository<Vehicle> _fakeRepository;

        protected given_an_integrated_parking_lot()
        {
            //Arrange
            _fakeRepository = new FakeRepository<Vehicle>();
            sut = new ParkingLot(100, new LongTermDiscounter(), new VehicleCostWithdrawalStrategyFactory(
                new List<VehicleCostCalculationStrategy>
                {
                    new BusCostCalculationStrategy(), new CarCostCalculationStrategy(),
                    new HelicopterCostCalculationStrategy(), new ElectricCarCostCalculationStrategy(),
                    new MotorCycleCostCalculationStrategy()
                }), new CalculateSpaces(2), new FakeLicenseVerifier(), _fakeRepository);
        }
    }
}
