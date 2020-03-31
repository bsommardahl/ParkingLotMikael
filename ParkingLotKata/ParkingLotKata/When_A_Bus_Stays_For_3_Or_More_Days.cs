using FluentAssertions;
using Xunit;

namespace ParkingLotKata
{
    public class When_A_Bus_Stays_For_3_Or_More_Days : given_a_parking_lot
    {
        readonly Driver _driver;
        readonly Bus _vehicle;


        public When_A_Bus_Stays_For_3_Or_More_Days()
        {
            _driver = new Driver();
            _vehicle = new Bus(_driver);
        }

        [Fact]
        public void Should_Be_Charged_28_80_Dollar_For_4_Days()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _parkingLot.AddDay(_vehicle, 4);

            //Assert
            _driver.Wallet.Should().Be(71.2);
        }
    }

}
