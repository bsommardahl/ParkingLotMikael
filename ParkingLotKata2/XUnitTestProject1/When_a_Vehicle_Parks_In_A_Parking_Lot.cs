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
            var sut = new ParkingLot(0, 0);
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

    public class when_withdrawing_the_cost_for_a_car
    {
        [Fact]
        public void should_withdraw_the_car_cost()
        {
            //Arrange
            var sut = new CarCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Car>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new Car(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(5));
        }

    }
    public class when_withdrawing_the_cost_for_a_electric_car
    {
        [Fact]
        public void should_withdraw_the_electric_car_cost()
        {
            //Arrange
            var sut = new ElectricCarCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<ElectricCar>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new ElectricCar(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(2.5));
        }

    }
    public class when_withdrawing_the_cost_for_a_car_with_trump_sticker
    {
        [Fact]
        public void should_withdraw_the_car_cost_times_two()
        {
            //Arrange
            var sut = new CarCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Car>;
            var driver = Mock.Of<IDriver>();
            var vehicle = new Car(driver, true);

            //Act
            sut.Execute(vehicle, 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(10));
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
            sut.Execute(new Bus(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(9));
        }

    }

    public class when_withdrawing_cost_for_a_motorcycle
    {
        [Fact]
        public void should_withdraw_the_amount_for_a_motorcycle()
        {
            //Arrange
            var sut = new MotorCycleCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<MotorCycle>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new MotorCycle(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(.5));
        }

    }
    public class when_withdrawing_the_cost_of_a_helicopter
    {
        [Fact]
        public void should_withdraw_the_helicopter_cost()
        {
            //Arrange
            var sut = new HelicopterCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Helicopter>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new Helicopter(driver), 1);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(35));
        }

    }
    public class when_vehicle_has_stayed_for_3_or_more_days
    {
        [Fact]
        public void should_get_20_precent_discount_on_cost()
        {
            //Arrange
            var sut = new BusCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Bus>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new Bus(driver), 4);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(28.80));
        }

    }

    public class when_vehicle_has_stayed_for_6_or_more_days
    {
        [Fact]
        public void should_get_30_percent_discount_on_cost()
        {
            //Arrange
            var sut = new CarCostWithdrawalStrategy() as IVehicleCostWithdrawalStrategy<Car>;
            var driver = Mock.Of<IDriver>();

            //Act
            sut.Execute(new Car(driver), 8);

            //Assert
            Mock.Get(driver).Verify(x => x.Withdraw(28));
        }
    }
}
