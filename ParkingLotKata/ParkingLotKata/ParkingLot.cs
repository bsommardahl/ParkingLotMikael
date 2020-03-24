using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace ParkingLotKata
{
    public class ParkingLot
    {
        readonly IEnumerable<IAddDayStrategy> _addDayStrategies;

        public ParkingLot(int spaces, IEnumerable<IAddDayStrategy> addDayStrategies)
        {
            _addDayStrategies = addDayStrategies;
            Spaces = spaces;
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
            Spaces -= vehicle.GetSize();
            //
            // if (Spaces < 1) return;
            // if (vehicle is Motorcycle)
            //     Spaces -= 0.5;
            // else if (vehicle is Bus)
            //     Spaces -= 2;
            // else if (vehicle is Helicopter)
            //     Spaces -= 8;
            // else
            //     Spaces--;
        }

        public double Spaces { get; private set; }
    }
}