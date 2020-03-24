using System.Collections.Generic;
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

    public abstract class given_a_parking_lot
    {
        protected List<IAddDayStrategy> _addDayStrategies;
        protected ParkingLot _parkingLot;

        public given_a_parking_lot()
        {
            _addDayStrategies = new List<IAddDayStrategy>
            {
                new ElectricCarStrategy(),
                new ElectricBusStrategy(),
                new TrumpCarStrategy(),
                new HeliStrategy(),
                new LongTermBusStrategy(),
                new LongTermCarStrategy(),
                new DefaultCar(),
                new DefaultBus(),
                new DefaultMoto(),
                new DefaultHeli(),
            };

            _parkingLot = new ParkingLot(50, _addDayStrategies);
        }
    }
}