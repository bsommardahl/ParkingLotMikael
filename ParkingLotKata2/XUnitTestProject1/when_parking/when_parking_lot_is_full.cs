using System;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public abstract class given_a_parking_lot
    {
        protected readonly ParkingLot Sut;
        protected readonly ILongTermDiscounter _longTermDiscounter;
        protected readonly IVehicleCostWithdrawalStrategyFactory _vehicleCostWithdrawalStrategyFactory;
        protected readonly int _spacesBeforeUnpark;

        protected given_a_parking_lot()
        {
            var metersPerSpace = 2;
            _spacesBeforeUnpark = 100;
            _longTermDiscounter = A.Fake<ILongTermDiscounter>();
            _vehicleCostWithdrawalStrategyFactory = A.Fake<IVehicleCostWithdrawalStrategyFactory>();
            Sut = new ParkingLot(_spacesBeforeUnpark, metersPerSpace, _longTermDiscounter,
                _vehicleCostWithdrawalStrategyFactory);
        }
    }

    public class when_unparking_a_vehicle : given_a_parking_lot
    {
        readonly IVehicle _vehicle;
        readonly int _days;
        IDriver _driver;

        IVehicleCostWithdrawalStrategy<IVehicle> _vehicleCostWithdrawalStrategy;
        private int _chargeAmount;
        private int _discountedAmount;

        public when_unparking_a_vehicle()
        {
            //Arrange
            var vehicleLength = 2;
            _days = 1;
            _vehicle = A.Fake<IVehicle>();
            _driver = A.Fake<IDriver>();
            A.CallTo(() => _vehicle.Driver).Returns(_driver);
            A.CallTo(() => _vehicle.Length).Returns(vehicleLength);

            _vehicleCostWithdrawalStrategy = A.Fake<IVehicleCostWithdrawalStrategy<IVehicle>>();
            A.CallTo(() => _vehicleCostWithdrawalStrategyFactory.Create(_vehicle)).Returns(_vehicleCostWithdrawalStrategy);

            _chargeAmount = 10;
            A.CallTo(() => _vehicleCostWithdrawalStrategy.Execute(_vehicle, _days)).Returns(_chargeAmount);

            _discountedAmount = 1000;
            A.CallTo(() => _longTermDiscounter.Discount(_days, _chargeAmount)).Returns(_discountedAmount);

            //Act
            Sut.UnparkVehicle(_vehicle, _days);
        }

        [Fact]
        public void should_add_spaces_back()
        {
            //Assert
            Sut.Spaces.Should().Be(_spacesBeforeUnpark + 1);
        }

        [Fact]
        public void should_charge_the_driver()
        {
            //Assert
            A.CallTo(() => _driver.Withdraw(_discountedAmount)).MustHaveHappened();
        }



        public class when_parking_lot_is_full : given_a_parking_lot
        {
            [Fact]
            public void should_reject_new_vehicles()
            {
                //Arrange
                var vehicle = A.Fake<IVehicle>();

                //Act
                Action act = () => Sut.ParkVehicle(vehicle);

                //Assert
                act.Should().Throw<NoMoreSpaceException>();
            }
        }
    }
}
