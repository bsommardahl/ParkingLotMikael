using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotKata
{
    public abstract class given_a_parking_lot
    {
        protected List<IAddDayStrategy> _addDayStrategies;
        protected List<IParkingLotSizeStrategy> _sizeStrategies;
        protected ParkingLot _parkingLot;

        public given_a_parking_lot()
        {
            _addDayStrategies = new List<IAddDayStrategy>
            {
                new CarStrategy(),
                new HelicopterStrategy(),
                new BusStrategy(),
                new MotorcycleStrategy(),

            };
            _sizeStrategies = new List<IParkingLotSizeStrategy>
            {
                new CarSizeStrategy(),
                new BusSizeStrategy(),
                new MotorcycleSizeStrategy(),
                new HelicopterSizeStrategy()

            };

            var addDayStrategyFactory = new AddDayStrategyFactory(_addDayStrategies) as IAddDayStrategyFactory;
            _parkingLot = new ParkingLot(50, addDayStrategyFactory, _sizeStrategies);
        }
    }

    public class AddDayStrategyFactory : IAddDayStrategyFactory
    {
        readonly IEnumerable<IAddDayStrategy> _addDayStrategies;

        public AddDayStrategyFactory(IEnumerable<IAddDayStrategy> addDayStrategies)
        {
            _addDayStrategies = addDayStrategies;
        }

        public IAddDayStrategy<T> Create<T>(T vehicle, int days) where T : Vehicle
        {
            //var strategy = _addDayStrategies.First(x =>
            //    x.GetType().GetInterfaces()
            //      .Any(i => i.GetGenericArguments().All(a => a.Name == vehicle.GetType().Name)));

            foreach (var strategy in _addDayStrategies)
            {
                var test = strategy.GetType().GetInterfaces().SelectMany(a => a.GenericTypeArguments.Any(x => x.Name.ToString() == vehicle.GetType().Name));


            }

            return null;

            //return (IAddDayStrategy<T>)strategy;
        }
    }

    public interface IAddDayStrategyFactory
    {
        IAddDayStrategy<T> Create<T>(T vehicle, int days) where T : Vehicle;
    }
}