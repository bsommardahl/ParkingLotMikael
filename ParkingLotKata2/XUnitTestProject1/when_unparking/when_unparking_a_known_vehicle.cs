using System;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1.when_unparking
{
    public class when_unparking_an_unknown_vehicle : given_a_parking_lot
    {
        [Fact]
        public void should_throw_an_exception()
        {
            
            //Act
            Action unparkAction = () => Sut.UnparkVehicle(A.Fake<IVehicle>(), 1);

            //Assert
            unparkAction.Should().Throw<UnknownVehicleException>();
        }

    }

    public class when_unparking_a_known_vehicle : given_a_parking_lot
    {
        readonly IVehicle _vehicle;
        readonly int _days;
        IDriver _driver;

        IVehicleCostCalculationStrategy<IVehicle> _vehicleCostCalculationStrategy;
        int _chargeAmount;
        int _discountedAmount;

        public when_unparking_a_known_vehicle()
        {
            //Arrange
            var vehicleLength = 2;
            _days = 1;
            _vehicle = A.Fake<IVehicle>();
            _driver = A.Fake<IDriver>();
            A.CallTo(() => _vehicle.Driver).Returns(_driver);
            A.CallTo(() => _vehicle.Length).Returns(vehicleLength);

            _vehicleCostCalculationStrategy = A.Fake<IVehicleCostCalculationStrategy<IVehicle>>();
            A.CallTo(() => _vehicleCostWithdrawalStrategyFactory.Create(_vehicle))
                .Returns(_vehicleCostCalculationStrategy);

            _chargeAmount = 10;
            A.CallTo(() => _vehicleCostCalculationStrategy.Execute(_vehicle, _days)).Returns(_chargeAmount);

            _discountedAmount = 1000;
            A.CallTo(() => _longTermDiscounter.Discount(_days, _chargeAmount)).Returns(_discountedAmount);

            A.CallTo(() => _calculateSpaces.GetSpaces(_vehicle)).Returns(1);

            Sut.ParkVehicle(_vehicle);
            
            //Act
            Sut.UnparkVehicle(_vehicle, _days);
        }

        [Fact]
        public void should_add_spaces_back()
        {
            //Assert
            Sut.Spaces.Should().Be(_originalAmountOfSpaces);
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
                A.CallTo(() => vehicle.Length).Returns(1);
                A.CallTo(() => _calculateSpaces.GetSpaces(vehicle)).Returns(1000);

                //Act
                Action act = () => Sut.ParkVehicle(vehicle);

                //Assert
                act.Should().Throw<NoMoreSpaceException>();
            }
        }
    }
}