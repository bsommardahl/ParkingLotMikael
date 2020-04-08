using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_Parking_A_Vehicle : given_a_parking_lot
    {
        [Fact]
        public void should_allow_the_vehicle_to_be_parked()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(metersPerSpace);
            A.CallTo(() => _calculateSpaces.GetSpaces(vehicle)).Returns(1);
            //Act
            Sut.ParkVehicle(vehicle);

            //Assert
            Sut.Spaces.Should().Be(99);

        }
    }

    public class when_calculating_spaces
    {
        private CalculateSpaces _sut;


        public when_calculating_spaces()
        {
            _sut = new CalculateSpaces(2);
        }

        [Fact]
        public void should_provide_one_space_per_every_two_meter()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(metersPerSpace);

            //Act
            var spaces = _sut.GetSpaces(vehicle);

            //Assert
            spaces.Should().Be(1);
        }
    }
}
