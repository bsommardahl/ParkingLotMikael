using System;
using FluentAssertions;
using Moq;
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
            _longTermDiscounter = Mock.Of<ILongTermDiscounter>();
            _vehicleCostWithdrawalStrategyFactory = Mock.Of<IVehicleCostWithdrawalStrategyFactory>();
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
            _vehicle = Mock.Of<IVehicle>();
            _driver = Mock.Of<IDriver>();
            Mock.Get(_vehicle).SetupGet(x => x.Driver).Returns(_driver);
            Mock.Get(_vehicle).SetupGet(x => x.Length).Returns(vehicleLength);

            _vehicleCostWithdrawalStrategy = Mock.Of<IVehicleCostWithdrawalStrategy<IVehicle>>();
            Mock.Get(_vehicleCostWithdrawalStrategyFactory).Setup(x => x.Create(_vehicle))
                .Returns(_vehicleCostWithdrawalStrategy);

            _chargeAmount = 10;
            Mock.Get(_vehicleCostWithdrawalStrategy)
                .Setup(x => x.Execute(_vehicle, _days)).Returns(_chargeAmount);

            _discountedAmount = 1000;
            Mock.Get(_longTermDiscounter).Setup(x => x.Discount(_days, _chargeAmount)).Returns(_discountedAmount);

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
            Mock.Get(_driver).Verify(x => x.Withdraw(_discountedAmount));
        }



        public class when_parking_lot_is_full : given_a_parking_lot
        {
            [Fact]
            public void should_reject_new_vehicles()
            {
                //Arrange
                var vehicle = Mock.Of<IVehicle>();

                //Act
                Action act = () => Sut.ParkVehicle(vehicle);

                //Assert
                act.Should().Throw<NoMoreSpaceException>();
            }
        }
    }
}
