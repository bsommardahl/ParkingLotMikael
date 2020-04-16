using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_withdrawing_cost_for_a_bus
    {
        [Fact]
        public void should_withdraw_the_amount_for_a_bus()
        {
            //Arrange
            var sut = new BusCostCalculationStrategy() as IVehicleCostCalculationStrategy<Bus>;
            var driver = A.Fake<IDriver>();

            //Act
            var amount = sut.Execute(new Bus(driver), 1);

            //Assert
            amount.Should().Be(9);
        }
    }
}