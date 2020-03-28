using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace XUnitTestProject1
{
    public class When_a_Car_Parks
    {
        private Car _car;
        private List<IVehicleStrategy> _strategies;

        public When_a_Car_Parks()
        {
            _car = new Car(new Driver());
            _car.Driver.AddToWallet(50);

            _strategies = new List<IVehicleStrategy>()
            {
                new CarStrategy()
            };
        }
        [Fact]
        public void Should_Charge_Driver_5_Dollar()
        {
            //Arrange
            var factory = new StrategyFactory(_strategies);
            var strategy = factory.Create(_car) as IVehicleStrategy<Car>;

            //Act
            strategy?.Execute(_car);

            //Assert
            _car.Driver.Wallet.Should().Be(45);

        }
    }

    public class CarStrategy : IVehicleStrategy<Car>
    {
        public void Execute(Car vehicle)
        {
            const int basePrice = 5;
            vehicle.Driver.Withdraw(basePrice);
        }
    }

    public interface IVehicleStrategy
    {
    }
    public interface IVehicleStrategy<in T> : IVehicleStrategy where T : Vehicle
    {
        void Execute(T vehicle);
    }



    public interface IStrategyFactory
    {
        IVehicleStrategy Create(Vehicle vehicle);
    }


    public class Car : Vehicle
    {
        public Car(Driver driver) : base(driver)
        {
        }
    }

    public class Vehicle
    {
        public Vehicle(Driver driver)
        {
            Driver = driver;
        }

        public Driver Driver { get; }
    }

    public class Driver
    {
        public double Wallet { get; private set; }

        public void AddToWallet(int money)
        {
            Wallet += money;
        }

        public void Withdraw(int money)
        {
            Wallet -= money;
        }
    }

    public class StrategyFactory : IStrategyFactory
    {
        private List<IVehicleStrategy> _vehicleStrategies;


        public StrategyFactory(List<IVehicleStrategy> vehicleStrategies)
        {
            _vehicleStrategies = vehicleStrategies;
        }


        public IVehicleStrategy Create(Vehicle vehicle)
        {
            foreach (var strategy in _vehicleStrategies)
            {

                var strategyType = strategy.GetType().GetInterfaces().Select(x => x.GenericTypeArguments).First().First();

                if (strategyType == vehicle.GetType())
                {
                    return strategy;
                }
            }

            return null;
        }

        public IVehicleStrategy<Vehicle> Execute(Vehicle vehicle, int days)
        {
            return null;
        }
    }
}
