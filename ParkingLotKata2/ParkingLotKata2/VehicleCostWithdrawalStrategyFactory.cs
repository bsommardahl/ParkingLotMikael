using System.Collections.Generic;
using System.Linq;

namespace ParkingLotKata2
{
    public class VehicleCostWithdrawalStrategyFactory : IVehicleCostWithdrawalStrategyFactory
    {
        readonly List<IVehicleCostCalculationStrategy> _vehicleStrategies;


        public VehicleCostWithdrawalStrategyFactory(List<IVehicleCostCalculationStrategy> vehicleStrategies)
        {
            _vehicleStrategies = vehicleStrategies;
        }


        public IVehicleCostCalculationStrategy Create(Vehicle vehicle)
        {

            foreach (var strategy in _vehicleStrategies)
            {
                var strategyType = strategy.GetType().GetInterfaces().SelectMany(x => x.GenericTypeArguments)
                    .First();

                if (strategyType == vehicle.GetType()) return strategy;
            }

            throw new NoMatchingVehicleCostWithdrawalStrategyException(vehicle);
        }
    }
}