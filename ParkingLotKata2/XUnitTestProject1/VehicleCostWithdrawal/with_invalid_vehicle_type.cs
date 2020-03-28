using System;
using System.Collections.Generic;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1.VehicleCostWithdrawal
{
    public class with_invalid_vehicle_type
    {
        [Fact]
        public void should_return_the_matching_strategy()
        {
            //Arrange
            var strategies = new List<IVehicleCostCalculationStrategy>()
            {
                //new CarCostWithdrawalStrategy()
            };
            var factory = new VehicleCostWithdrawalStrategyFactory(strategies);

            //Act
            Func<IVehicleCostWithdrawalStrategy<Car>> act = () =>
                factory.Create(new Car(new Driver())) as IVehicleCostWithdrawalStrategy<Car>;

            //Assert
            act.Should().Throw<NoMatchingVehicleCostWithdrawalStrategyException>();
        }
    }
}