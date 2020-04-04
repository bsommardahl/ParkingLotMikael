using FluentAssertions;
using Moq;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_withdrawing_the_cost_for_a_car_with_trump_sticker
    {
        [Fact]
        public void should_withdraw_the_car_cost_times_two()
        {
            //Arrange
            var sut = new CarCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Car>;
            var driver = Mock.Of<IDriver>();
            var vehicle = new Car(driver, true);

            //Act
            var amount = sut.Execute(vehicle, 1);

            //Assert
            amount.Should().Be(10);
        }

    }
}