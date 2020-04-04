using FluentAssertions;
using Moq;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_withdrawing_cost_for_a_motorcycle
    {
        [Fact]
        public void should_withdraw_the_amount_for_a_motorcycle()
        {
            //Arrange
            var sut = new MotorCycleCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<MotorCycle>;
            var driver = Mock.Of<IDriver>();

            //Act
            var amount = sut.Execute(new MotorCycle(driver), 1);

            //Assert
            amount.Should().Be(.5);
        }

    }
}