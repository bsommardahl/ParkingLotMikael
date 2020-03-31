using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using FluentAssertions;
using Moq;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_unparking_a_vehicle
    {
        public when_unparking_a_vehicle()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicleLength = 2;
            var spacesBeforeUnpark = 100;
            sut = new ParkingLot(spacesBeforeUnpark, metersPerSpace, Mock.Of<IDicounrter>(), Mock.Of<IVehicleCostWithdrawalStrategyFactory>());
            var days = 1;
            var vehicle = Mock.Of<IVehicle>();
            Mock.Get(vehicle).SetupGet(x => x.Length).Returns(vehicleLength);
        }
        [Fact]
        public void should_add_spaces_back()
        {
            
            
            //Act
            sut.UnparkVehicle(vehicle, days);

            //Assert
            sut.Spaces.Should().Be(spacesBeforeUnpark + 1);
        }
        
        [Fact]
        public void should_add_spaces_back()
        {
            //discount
            //program agasint a mocked discounter
            }

        [Fact]
        public void should_add_spaces_back()
        {
            //charge the driver
            //program against a mocked strategy and driver
        }

    }
    public class when_parking_lot_is_full
    {
        [Fact]
        public void should_reject_new_vehicles()
        {
            //Arrange
            var sut = new ParkingLot(0, 0);
            var vehicle = Mock.Of<IVehicle>();

            //Act
            Action act = () => sut.ParkVehicle(vehicle);

            //Assert
            act.Should().Throw<NoMoreSpaceException>();
        }

    }
}
