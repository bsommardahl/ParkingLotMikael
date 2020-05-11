using System;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1.when_unparking
{
    public class when_unparking_an_unknown_vehicle : given_a_parking_lot
    {
        [Fact]
        public void should_throw_an_exception()
        {
            //Act
            const string license = "Invalid";
            A.CallTo(() => _vehicleRepository.Get(license)).Returns(Task.FromResult<Vehicle>(null));
            Func<Task> unparkAction = async () => await Sut.UnparkVehicle(license, 1);

            //Assert
            unparkAction.Should().Throw<UnknownVehicleException>();
        }
    }
}