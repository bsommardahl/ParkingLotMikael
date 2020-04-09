using System.Collections.Generic;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1.VehicleCostWithdrawal
{
    public class with_valid_vehicle_type
    {
        [Fact]
        public void should_return_the_matching_strategy()
        {
            //Arrange
            var strategies = new List<IVehicleCostCalculationStrategy>()
            {
                new BusCostCalculationStrategy(),
                new CarCostCalculationStrategy(),
                new HelicopterCostCalculationStrategy()
            };
            var factory = new VehicleCostWithdrawalStrategyFactory(strategies);

            //Act
            var strategy = factory.Create(new Car(new Driver())) as IVehicleCostCalculationStrategy<Car>;

            //Assert
            strategy.Should().BeOfType<CarCostCalculationStrategy>();
        }
    }
}