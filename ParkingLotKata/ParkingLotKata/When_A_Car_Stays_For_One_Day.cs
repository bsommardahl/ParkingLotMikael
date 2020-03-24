using FluentAssertions;
using Xunit;

namespace ParkingLotKata
{
    public class When_A_Car_Stays_For_One_Day: given_a_parking_lot
    {
        readonly Driver _driver;
        readonly Vehicle _normalVehicle;
        
        readonly Vehicle _trumpStickerVehicle;
        Vehicle _electricVehicle;

        public When_A_Car_Stays_For_One_Day()
        {
            _driver = new Driver();
            _normalVehicle = new Car(_driver);
            _trumpStickerVehicle = new Car(_driver, MotorType.Normal, true);
            _electricVehicle = new Car(_driver, MotorType.Electric, false);
            
        }

        [Fact]
        public void Should_Be_Charged_5_Dollar()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _parkingLot.AddDay(_normalVehicle);

            //Assert
            _driver.Wallet.Should().Be(95);
        }

        [Fact]
        public void Should_Be_Charged_10_Dollar_Car_Has_Trump_Sticker()
        {
            //Arrange
            _driver.AddMoney(100);


            //Act
            _parkingLot.AddDay(_trumpStickerVehicle);

            //Assert
            _driver.Wallet.Should().Be(90);
        }

        [Fact]
        public void Should_Take_One_Space_From_The_Lot()
        {
            //Arrange

            //Act
            _parkingLot.Park(_normalVehicle);
            //Assert
            _parkingLot.Spaces.Should().Be(49);
        }

        [Fact]
        public void Electric_Vehicle_Should_Be_Charged_2_50_Dollar()
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