using FluentAssertions;
using Xunit;

namespace ParkingLotKata
{
    public class When_A_Vehicle_Attempts_To_Enter_A_Full_Lot: given_a_parking_lot
    {
        readonly Driver _driver;
        readonly Vehicle _normalVehicle;
        
        public When_A_Vehicle_Attempts_To_Enter_A_Full_Lot()
        {
            _driver = new Driver();
            _normalVehicle = new Car(_driver);

            for (var i = 0; i < 50; i++)
            {
                _parkingLot.Park(new Car(_driver));    
            }
        }

        [Fact]
        public void The_Driver_Should_Be_Charged_0_Dollar()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _parkingLot.AddDay(_normalVehicle);

            //Assert
            _driver.Wallet.Should().Be(100);
        }

        [Fact]
        public void Should_Reject_The_Car()
        {
            //Arrange

            //Act
            _parkingLot.Park(_normalVehicle);
            //Assert
            _parkingLot.Spaces.Should().Be(0);
        }
    }
}