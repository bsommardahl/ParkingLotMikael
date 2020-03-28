using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace XUnitTestProject1
{
    public class When_a_Vehicle_Parks_In_A_Parking_Lot
    {
        private Car _car;
        private ParkingLot _parkingLot;
        private List<IParkingLotSizeStrategy> _strategies;

        public When_a_Vehicle_Parks_In_A_Parking_Lot()
        {
            _parkingLot = new ParkingLot(50);
            _car = new Car(new Driver());
            _strategies = new List<IParkingLotSizeStrategy>
           {
               new CarSizeStrategy()
           };
        }
        [Fact]
        public void A_Car_Should_Take_One_Space()
        {
            //Arrange
            var factory = new ParkingLotSizeStrategyFactory(_strategies);
            var strategy = factory.Create(_car) as IParkingLotSizeStrategy<Car>;
            //Act
            strategy?.Execute(_parkingLot);

            //Assert
            _parkingLot.Spaces.Should().Be(49);

        }
        [Fact]
        public void If_only_One_Space_Left_and_A_Car_Park_No_More_Spaces()
        {
            //Arrange
            _parkingLot.RemoveSpaces(49);
            var factory = new ParkingLotSizeStrategyFactory(_strategies);
            var strategy = factory.Create(_car) as IParkingLotSizeStrategy<Car>;
            //Act
            strategy?.Execute(_parkingLot);

            //Assert
            _parkingLot.Spaces.Should().Be(0);

        }

        [Fact]
        public void If_No_Spaces_Left_Should_Reject_Vehicle()
        {
            //Arrange
            _parkingLot.RemoveSpaces(50);
            var factory = new ParkingLotSizeStrategyFactory(_strategies);
            var strategy = factory.Create(_car) as IParkingLotSizeStrategy<Car>;
            //Act
            strategy?.Execute(_parkingLot);

            //Assert
            _parkingLot.Spaces.Should().Be(0);
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => strategy?.Execute(_parkingLot));

        }
    }



    public class ParkingLotSizeStrategyFactory
    {
        private readonly List<IParkingLotSizeStrategy> _strategies;

        public ParkingLotSizeStrategyFactory(List<IParkingLotSizeStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IParkingLotSizeStrategy Create(Vehicle vehicle)
        {
            foreach (var strategy in _strategies)
            {
                var interfaces = strategy.GetType().GetInterfaces();
                var typeses = interfaces.SelectMany(x => x.GenericTypeArguments);
                var strategyType = typeses.First();

                if (strategyType == vehicle.GetType())
                {
                    return strategy;
                }
            }

            return null;
        }
    }

    public class CarSizeStrategy : IParkingLotSizeStrategy<Car>
    {
        public void Execute(ParkingLot lot)
        {
            lot.Spaces -= 1;
        }
    }

    public interface IParkingLotSizeStrategy
    {

    }

    public interface IParkingLotSizeStrategy<in T> : IParkingLotSizeStrategy where T : Vehicle
    {
        void Execute(ParkingLot lot);
    }

    public class ParkingLot
    {


        public ParkingLot(int spaces)
        {
            Spaces = spaces;
        }

        public int Spaces { get; set; }

        public void RemoveSpaces(int spaces)
        {
            Spaces -= spaces;
        }
    }
}
