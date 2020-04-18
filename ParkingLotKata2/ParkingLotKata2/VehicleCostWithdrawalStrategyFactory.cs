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


        public IVehicleCostCalculationStrategy Create(IVehicle vehicle)

        {
            foreach (var strategy in _vehicleStrategies)
            {
                var strategyGenericType = strategy.GetType().GetInterfaces().SelectMany(x => x.GenericTypeArguments)
                    .First();

                if (strategyGenericType == vehicle.GetType()) return (IVehicleCostCalculationStrategy)strategy;
            }

            throw new NoMatchingVehicleCostWithdrawalStrategyException(vehicle);
        }
    }
}