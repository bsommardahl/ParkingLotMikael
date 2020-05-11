using System;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1.when_parking
{

    public class when_parking_lot_is_full : given_a_parking_lot
    {
        [Fact]
        public void should_reject_new_vehicles()
        {
            //Arrange
            var vehicle = A.Fake<Vehicle>();
            A.CallTo(() => vehicle.Length).Returns(1);
            A.CallTo(() => _calculateSpaces.GetSpaces(vehicle)).Returns(1000);

            //Act
            Func<Task> act = async () => await Sut.ParkVehicle(vehicle);

            //Assert
            act.Should().Throw<NoMoreSpaceException>();
        }
    }
}
