using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using FluentAssertions;
using Moq;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_parking_lot_is_full
    {
        [Fact]
        public void should_reject_new_vehicles()
        {
            //Arrange
            var sut = new ParkingLot(0,0);
            var vehicle = Mock.Of<IVehicle>();
            
            //Act
            Action act = () => sut.ParkVehicle(vehicle);

            //Assert
            act.Should().Throw<NoMoreSpaceException>();
        }

    }

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

    }

    public class when_withdrawing_the_cost_for_a_car
    {
        [Fact]
        public void should_withdraw_the_car_cost()
        {
            //Arrange
            var sut = new CarCostWithdrawalStrategy();
            var driver = Mock.Of<IDriver>();
            var vehicle = new Car(driver);
            
            //Act
            sut.Execute(vehicle);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(5));
        }

    }

    public class when_withdrawing_cost_for_a_bus
    {
        [Fact]
        public void should_withdraw_the_amount_for_a_bus()
        {
            //Arrange
            var sut = new BusCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Bus>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new Bus(driver));

            //Assert
            Mock.Get(driver).Verify(x=> x.Withdraw(9));
        }

    }
}
