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
        public void should_throw_no_matching_vehicle_cost_withdrawal_strategy_exception()
        {
            //Arrange
            var strategies = new List<IVehicleCostCalculationStrategy>()
            {
                //new CarCostCalculationStrategy()
            };
            var factory = new VehicleCostWithdrawalStrategyFactory(strategies);

            //Act
            var action = new Action(() =>
            {
                factory.Create(new Car(new Driver(), "license"));
            });

            //Assert
            action.Should().Throw<NoMatchingVehicleCostWithdrawalStrategyException>();
        }
    }
}