using Moq;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_withdrawing_the_cost_of_a_helicopter
    {
        [Fact]
        public void should_withdraw_the_helicopter_cost()
        {
            //Arrange
            var sut = new HelicopterCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Helicopter>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new Helicopter(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(35));
        }

    }
}