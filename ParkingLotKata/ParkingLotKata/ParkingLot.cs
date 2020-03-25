using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace ParkingLotKata
{
    public class ParkingLot
    {
        readonly IEnumerable<IAddDayStrategy> _addDayStrategies;
        readonly IEnumerable<IParkingLotSizeStrategy> _sizeStrategies;

        public ParkingLot(int spaces, IEnumerable<IAddDayStrategy> addDayStrategies, IEnumerable<IParkingLotSizeStrategy> sizeStrategies)
        {
            _addDayStrategies = addDayStrategies;
            Spaces = spaces;
            _sizeStrategies = sizeStrategies;
        }

        public void AddDay(Vehicle vehicle, int days = 1)
        {
            if (Spaces < 1) return;

            var addDayStrategy = _addDayStrategies
                .First(x => x.CanExecute(vehicle, days));

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