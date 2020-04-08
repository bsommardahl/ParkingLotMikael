using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_parking_lot_has_enough_space : given_a_parking_lot
    {
        [Fact]
        public void should_allow_the_car_to_park()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(metersPerSpace);

            //Act
            Sut.ParkVehicle(vehicle);

            //Assert
            Sut.Spaces.Should().Be(99);
        }

        [Fact]
        public void should_take_two_spaces_if_bus()
        {
            //Arrange
            var vehicleLength = 4;
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(vehicleLength);

            //Act
            Sut.ParkVehicle(vehicle);

            //Assert
            Sut.Spaces.Should().Be(98);
        }

        [Fact]
        public void should_take_half_a_spaces_if_motorcycle()
        {
            //Arrange
            var vehicleLength = 1;
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(vehicleLength);

            //Act
            Sut.ParkVehicle(vehicle);

            //Assert
            Sut.Spaces.Should().Be(99.5);
        }

        [Fact]
        public void should_take_eight_spaces_if_helicopter()
        {
            //Arrange
            var vehicleLength = 16;

            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(vehicleLength);

            //Act
            Sut.ParkVehicle(vehicle);

            //Assert
            Sut.Spaces.Should().Be(92);
        }
    }
}