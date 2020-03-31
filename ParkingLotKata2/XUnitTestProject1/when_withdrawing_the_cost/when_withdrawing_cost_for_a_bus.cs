using Moq;
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
            var sut = new BusCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Bus>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new Bus(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(9));
        }

    }
}