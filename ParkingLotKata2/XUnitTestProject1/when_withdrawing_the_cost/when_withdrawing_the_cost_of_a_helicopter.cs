using FakeItEasy;
using FluentAssertions;
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
            var sut = new HelicopterCostCalculationStrategy() as VehicleCostCalculationStrategy<Helicopter>;
            var driver = A.Fake<IDriver>();

            //Act
            var amount = sut.Execute(new Helicopter(driver, "license"), 1);

            //Assert
            amount.Should().Be(35);
        }
    }
}