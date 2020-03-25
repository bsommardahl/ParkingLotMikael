using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace ParkingLotKata
{
    public class ParkingLot
    {
        readonly IAddDayStrategyFactory _addDayStrategyFactory;
        readonly IEnumerable<IParkingLotSizeStrategy> _sizeStrategies;

        public ParkingLot(int spaces, IAddDayStrategyFactory addDayStrategyFactory, IEnumerable<IParkingLotSizeStrategy> sizeStrategies)
        {
            Spaces = spaces;
            _addDayStrategyFactory = addDayStrategyFactory;
            _sizeStrategies = sizeStrategies;
        }

        public void AddDay<T>(T vehicle, int days = 1) where T : Vehicle
        {
            if (Spaces < 1) return;

            var addDayStrategy = _addDayStrategyFactory.Create(vehicle, days);
            
            addDayStrategy
                .Execute(vehicle, days);
        }

        public void Park(Vehicle vehicle)
        {
            if (Spaces < 1) return;
            var sizeStrategy = _sizeStrategies
                .First(x => x.CanExecute(vehicle));

            Spaces -= sizeStrategy
            .Execute();
        }

        public double Spaces { get; private set; }

    }
}