using System;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_withdrawing_the_cost_for_a_car
    {
        [Fact]
        public void should_withdraw_the_car_cost()
        {
            //Arrange
            var sut = new CarCostCalculationStrategy() as VehicleCostCalculationStrategy<Car>;
            var driver = A.Fake<IDriver>();

            //Act
            var amount = sut.Execute(new Car(new Guid(), driver, "license"), 1);

            //Assert
            amount.Should().Be(5);
        }
    }
}