using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace TestProject1
{
    public class when_parking_a_vehicle : given_an_integrated_parking_lot
    {
        [Fact]
        public void should_allow_it()
        {
            //Act
            sut.ParkVehicle(new Car(new Driver(), "license"));

            //Assert
            sut.Spaces.Should().Be(99);
        }
    }
}