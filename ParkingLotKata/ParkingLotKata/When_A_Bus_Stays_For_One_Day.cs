using FluentAssertions;
using Xunit;

namespace ParkingLotKata
{
    public class When_A_Bus_Stays_For_One_Day : given_a_parking_lot
    {
        readonly Driver _driver;
        readonly Vehicle _vehicle;
        Vehicle _electricVehicle;

        public When_A_Bus_Stays_For_One_Day()
        {
            _driver = new Driver();
            _vehicle = new Bus(_driver);
            _electricVehicle = new Car(_driver, MotorType.Electric);
        }

        [Fact]
        public void For_One_Day_Should_Be_Charged_9_Dollar()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _parkingLot.AddDay(_vehicle);

            //Assert
            _driver.Wallet.Should().Be(91);
        }

        [Fact]
        public void For_One_Day_Should_Take_Two_Space_From_The_Lot()
        {
            //Arrange

            //Act
            _parkingLot.Park(_vehicle);
            //Assert
            _parkingLot.Spaces.Should().Be(48);
        }

        [Fact]
        public void For_One_Day_Electric_Vehicle_Should_Be_Charged_4_50_Dollar()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _parkingLot.AddDay(_electricVehicle);

            //Assert
            _driver.Wallet.Should().Be(97.50);
        }

        [Fact]
        public void For_One_Day_Electric_Vehicle_Should_Be_Charged_4_50_Dollar()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _parkingLot.AddDay(_electricVehicle);

            //Assert
            _driver.Wallet.Should().Be(97.50);
        }
    }
}