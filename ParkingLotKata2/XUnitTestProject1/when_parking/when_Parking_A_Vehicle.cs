using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_Parking_A_Vehicle : given_a_parking_lot
    {
        readonly IDriver _driver;

        public when_Parking_A_Vehicle()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(metersPerSpace);
            A.CallTo(() => _calculateSpaces.GetSpaces(vehicle)).Returns(1);
            //Act
            Sut.ParkVehicle(vehicle);
        }

        [Fact]
        public void should_allow_the_vehicle_to_be_parked()
        {
            //Assert
            Sut.Spaces.Should().Be(99);
        }
    }
}