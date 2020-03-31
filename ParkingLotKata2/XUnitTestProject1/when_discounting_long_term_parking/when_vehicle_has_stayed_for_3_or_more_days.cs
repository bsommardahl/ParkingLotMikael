using FluentAssertions;
using Moq;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_vehicle_has_stayed_for_3_or_more_days
    {
        [Fact]
        public void should_get_20_precent_discount_on_cost()
        {
            //Arrange
            var sut = new DiscountWithdrawalStrategy() as IDiscountWithdrawalStrategy;
            
            //Act
            var discountedAmount = sut.Discount(4, 10.0);

            //Assert
            discountedAmount.Should().Be(8);
        }

    }
}