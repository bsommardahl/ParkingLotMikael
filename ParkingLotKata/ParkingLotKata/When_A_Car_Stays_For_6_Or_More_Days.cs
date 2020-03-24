using FluentAssertions;
using Xunit;

namespace ParkingLotKata
{
    public class When_A_Car_Stays_For_6_Or_More_Days: given_a_parking_lot
    {
        readonly Driver _driver;
        readonly Vehicle _vehicle;
        

        public When_A_Car_Stays_For_6_Or_More_Days()
        {
            _driver = new Driver();
            _vehicle = new Car(_driver);
        }

        [Fact]
        public void Should_Be_Charged_28_Dollar_For_8_Days()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _parkingLot.AddDay(_vehicle, 8);

            //Assert
            _driver.Wallet.Should().Be(72);
        }
    }
}