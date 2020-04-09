using System;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1.when_unparking
{
    public class when_unparking_a_vehicle : given_a_parking_lot
    {
        readonly IVehicle _vehicle;
        readonly int _days;
        IDriver _driver;

        IVehicleCostCalculationStrategy<IVehicle> _vehicleCostCalculationStrategy;
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

            _vehicleCostCalculationStrategy = A.Fake<IVehicleCostCalculationStrategy<IVehicle>>();
            A.CallTo(() => _vehicleCostWithdrawalStrategyFactory.Create(_vehicle)).Returns(_vehicleCostCalculationStrategy);

            _chargeAmount = 10;
            A.CallTo(() => _vehicleCostCalculationStrategy.Execute(_vehicle, _days)).Returns(_chargeAmount);

            _discountedAmount = 1000;
            A.CallTo(() => _longTermDiscounter.Discount(_days, _chargeAmount)).Returns(_discountedAmount);

            A.CallTo(() => _calculateSpaces.GetSpaces(_vehicle)).Returns(1);

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