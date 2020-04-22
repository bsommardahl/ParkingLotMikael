using System;
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
            Action unparkAction = () => Sut.UnparkVehicle("invalided", 1);

            //Assert
            unparkAction.Should().Throw<UnknownVehicleException>();
        }
    }
}