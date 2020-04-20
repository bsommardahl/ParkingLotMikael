using System.Collections.Generic;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1.when_creating_a_cost_calculation_strategy
{
    public class with_valid_vehicle_type
    {
        public class FakeCarStrategy : IVehicleCostCalculationStrategy<Car>
        {
            readonly double _amount;

            public FakeCarStrategy(double amount)
            {
                _amount = amount;
            }
            public double Execute(Car vehicle, int days)
            {
                return _amount;
            }
        }
        
        [Fact]
        public void should_return_a_function_that_uses_the_matching_strategy()
        {
            //Arrange
            var expectedAmount = 1234;
            var strategies = new List<IVehicleCostCalculationStrategy>()
            {
                new BusCostCalculationStrategy(),
                new FakeCarStrategy(expectedAmount),
                new HelicopterCostCalculationStrategy()
            };
            var factory = new VehicleCostWithdrawalStrategyFactory(strategies);

            //Act
            var vehicle = new Car(new Driver(), "license");
            var strategy = factory.Create(vehicle);
            
            //Assert
            strategy(vehicle, 1).Should().Be(expectedAmount);
        }
    }
}