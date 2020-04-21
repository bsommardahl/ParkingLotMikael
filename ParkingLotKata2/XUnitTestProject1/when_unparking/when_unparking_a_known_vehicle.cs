using System;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1.when_unparking
{
    public partial class when_unparking_a_known_vehicle : given_a_parking_lot
    {
        readonly IVehicle _vehicle;
        readonly int _days;
        IDriver _driver;
        int _chargeAmount;
        int _discountedAmount;
        private readonly string _license;
        private double _moneyInWallet;

        public when_unparking_a_known_vehicle()
        {
            //Arrange
            var vehicleLength = 2;
            _days = 1;
            _moneyInWallet = 2000;
            _license = "Valid";
            _vehicle = A.Fake<IVehicle>();
            _driver = A.Fake<IDriver>();
            _chargeAmount = 10;
            _discountedAmount = 1000;

            A.CallTo(() => _vehicle.Driver).Returns(_driver);
            A.CallTo(() => _vehicle.Driver.GetWalletSum()).Returns(_moneyInWallet);
            A.CallTo(() => _vehicle.Length).Returns(vehicleLength);
            A.CallTo(() => _vehicle.License).Returns(_license);

            A.CallTo(() => _vehicleCostWithdrawalStrategyFactory.Create(_vehicle))
                .Returns((vehicle, days) => _chargeAmount);

            A.CallTo(() => _longTermDiscounter.Discount(_days, _chargeAmount)).Returns(_discountedAmount);
            A.CallTo(() => _calculateSpaces.GetSpaces(_vehicle)).Returns(1);

            Sut.ParkVehicle(_vehicle);

            //Act
            Sut.UnparkVehicle(_license, _days);
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

        [Fact]
        public void with_not_enough_money_should_throw_an_exception()
        {

            //Arrange
            A.CallTo(() => _vehicle.Driver.GetWalletSum()).Returns(0);

            //Act
            Sut.ParkVehicle(_vehicle);
            Action unparkAction = () => Sut.UnparkVehicle(_license, 1);

            //Assert
            unparkAction.Should().Throw<NotEnoughMoneyException>("The driver do not have enough money");

            //CleanUp
            A.CallTo(() => _vehicle.Driver.GetWalletSum()).Returns(_moneyInWallet);
            Sut.UnparkVehicle(_license, 1);
        }
    }
}