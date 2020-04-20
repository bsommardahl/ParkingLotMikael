using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace TestProject1
{
    public class when_unparking_a_vehicle : given_an_integrated_parking_lot
    {
        readonly Driver driver;
        readonly int _startingBalance;

        public when_unparking_a_vehicle()
        {
            //Arrange
            _startingBalance = 10;
            driver = new Driver();
            driver.AddToWallet(_startingBalance);
            var vehicle = new Car(driver, "license");
            sut.ParkVehicle(vehicle);

            //Act
            sut.UnparkVehicle(vehicle.License, 1);
        }

        [Fact]
        public void should_replace_the_spaces()
        {
            //Assert
            sut.Spaces.Should().Be(100);
        }

        [Fact]
        public void should_charge_the_driver()
        {
            //Assert
            driver.Wallet.Should().Be(_startingBalance - 5);
        }
    }
}