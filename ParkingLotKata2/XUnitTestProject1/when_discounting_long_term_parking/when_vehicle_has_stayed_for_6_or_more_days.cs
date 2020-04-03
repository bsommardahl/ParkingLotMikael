using FluentAssertions;
using Moq;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_vehicle_has_stayed_for_6_or_more_days
    {
        [Fact]
        public void should_get_30_percent_discount_on_cost()
        {
            //Arrange
            var sut = new LongTermDiscounter() as ILongTermDiscounter;
            
            //Act
            var discountedAmount = sut.Discount(8, 10.0);

            //Assert
            discountedAmount.Should().Be(7);
        }
    }
    
    public class when_vehicle_has_stayed_for_less_than_3_days
    {
        [Fact]
        public void should_not_discount()
        {
            //Arrange
            var sut = new LongTermDiscounter() as ILongTermDiscounter;
            
            //Act
            var discountedAmount = sut.Discount(2, 10.0);

            //Assert
            discountedAmount.Should().Be(10);
        }
    }
}