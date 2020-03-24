using FluentAssertions;
using Xunit;

namespace ParkingLotKata
{
    public class When_A_MotorCycle_Stays_For_One_Day
    {
        readonly Driver _driver;
        readonly Vehicle _moto;
        IAddDayStrategy _sut;

        public When_A_MotorCycle_Stays_For_One_Day()
        {
            _driver = new Driver();
            _moto = new Motorcycle(_driver);
            
            _sut = new DefaultMoto() as IAddDayStrategy;
        }

        [Fact]
        public void Should_Be_Charged_3_Dollar()
        {
            //Arrange
            _driver.AddMoney(100);

            //Act
            _sut.Execute(_moto, 1);
            
            //Assert
            _driver.Wallet.Should().Be(97);
        }

        [Fact]
        public void Should_be_able_to_execute_for_the_situation()
        {
            //arrange
            //act
            var result = _sut.CanExecute(_moto, 1);
            //assert
            result.Should().BeTrue();
        }
        
        // [Fact]
        // public void Should_Take_Half_A_Space_From_The_Lot()
        // {
        //     //Arrange
        //
        //     //Act
        //     _parkingLot.Park(_moto);
        //     //Assert
        //     _parkingLot.Spaces.Should().Be(49.5);
        // }
    }
}