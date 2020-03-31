using FluentAssertions;
using Moq;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_parking_lot_has_enough_space
    {
        [Fact]
        public void should_allow_the_car_to_park()
        {
            //Arrange
            var metersPerSpace = 2;
            var spaces = 10;
            var sut = new ParkingLot(spaces, metersPerSpace);
            var vehicle = Mock.Of<IVehicle>();
            Mock.Get(vehicle).SetupGet(x => x.Length).Returns(metersPerSpace);

            //Act
            sut.ParkVehicle(vehicle);

            //Assert
            sut.Spaces.Should().Be(9);
        }

        [Fact]
        public void should_take_two_spaces_if_bus()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicleLength = 4;
            var spaces = 10;
            var sut = new ParkingLot(spaces, metersPerSpace);
            var vehicle = Mock.Of<IVehicle>();
            Mock.Get(vehicle).SetupGet(x => x.Length).Returns(vehicleLength);

            //Act
            sut.ParkVehicle(vehicle);

            //Assert
            sut.Spaces.Should().Be(8);
        }

        [Fact]
        public void should_take_half_a_spaces_if_motorcycle()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicleLength = 1;
            var spaces = 10;
            var sut = new ParkingLot(spaces, metersPerSpace);
            var vehicle = Mock.Of<IVehicle>();
            Mock.Get(vehicle).SetupGet(x => x.Length).Returns(vehicleLength);

            //Act
            sut.ParkVehicle(vehicle);

            //Assert
            sut.Spaces.Should().Be(9.5);
        }

        [Fact]
        public void should_take_eight_spaces_if_helicopter()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicleLength = 16;
            var spaces = 10;
            var sut = new ParkingLot(spaces, metersPerSpace);
            var vehicle = Mock.Of<IVehicle>();
            Mock.Get(vehicle).SetupGet(x => x.Length).Returns(vehicleLength);

            //Act
            sut.ParkVehicle(vehicle);

            //Assert
            sut.Spaces.Should().Be(2);
        }
    }
}