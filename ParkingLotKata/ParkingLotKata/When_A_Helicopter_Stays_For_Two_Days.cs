using FluentAssertions;
using Xunit;

namespace ParkingLotKata
{
    public class When_A_Helicopter_Stays_For_Two_Days: given_a_parking_lot
    {
        readonly Driver _driver;
        readonly Vehicle _vehicle;

        public When_A_Helicopter_Stays_For_Two_Days()
        {
            _driver = new Driver();
            _vehicle = new Helicopter(_driver);
        }

        [Fact]
        public void Should_Be_Charged_70_Dollar()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _parkingLot.AddDay(_vehicle, 2);

            //Assert
            _driver.Wallet.Should().Be(30);
        }

        [Fact]
        public void Should_Take_8_Space_From_The_Lot()
        {
            //Arrange

            //Act
            _parkingLot.Park(_vehicle);
            //Assert
            _parkingLot.Spaces.Should().Be(42);
        }
    }
}