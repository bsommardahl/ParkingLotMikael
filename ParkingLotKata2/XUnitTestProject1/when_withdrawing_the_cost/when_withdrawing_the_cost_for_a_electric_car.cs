using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_withdrawing_the_cost_for_a_electric_car
    {
        [Fact]
        public void should_withdraw_the_electric_car_cost()
        {
            //Arrange
            var sut = new ElectricCarCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<ElectricCar>;
            var driver = A.Fake<IDriver>();

            //Act
            var amount = sut.Execute(new ElectricCar(driver), 1);

            //Assert
            amount.Should().Be(2.5);
        }

    }
}