using Moq;
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
            var sut = new CarCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Car>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new Car(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(5));
        }

    }
}