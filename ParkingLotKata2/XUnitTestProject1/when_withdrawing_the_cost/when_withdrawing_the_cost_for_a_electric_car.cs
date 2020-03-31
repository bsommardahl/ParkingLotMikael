using Moq;
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
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new ElectricCar(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(2.5));
        }

    }
}