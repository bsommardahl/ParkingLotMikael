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


        public IVehicleCostCalculationStrategy<T> Create<T>(T vehicle) where T : IVehicle

        {
            foreach (var strategy in _vehicleStrategies)
            {
                var strategyGenericType = strategy.GetType().GetInterfaces().SelectMany(x => x.GenericTypeArguments)
                    .First();

                if (strategyGenericType == vehicle.GetType())
                {
                    return (IVehicleCostCalculationStrategy<T>)strategy;
                }
            }

            throw new NoMatchingVehicleCostWithdrawalStrategyException(vehicle);
        }

        
    }
}