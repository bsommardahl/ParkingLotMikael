using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotKata2
{
    public class VehicleCostWithdrawalStrategyFactory : IVehicleCostWithdrawalStrategyFactory
    {
        readonly List<VehicleCostCalculationStrategy> _vehicleStrategies;


        public VehicleCostWithdrawalStrategyFactory(List<VehicleCostCalculationStrategy> vehicleStrategies)
        {
            _vehicleStrategies = vehicleStrategies;
        }


        public Func<T, int, double> Create<T>(T vehicle) where T : Vehicle

        {
            foreach (var strategy in _vehicleStrategies)
            {
                var strategyGenericType = strategy.GetType().GetInterfaces().SelectMany(x => x.GenericTypeArguments)
                    .First();

                if (strategyGenericType == vehicle.GetType())
                    return ((v, d) => GetAmountFromStrategy(strategy, v, d));
            }

            throw new NoMatchingVehicleCostWithdrawalStrategyException(vehicle);
        }

        double GetAmountFromStrategy<T>(VehicleCostCalculationStrategy strategy, T vehicle, int days) where T : Vehicle
        {
            var methodInfo = strategy.GetType().GetMethods().First(x => x.Name == "Execute");
            var amount = methodInfo.Invoke(strategy, new object[] { vehicle, days });
            return (double)amount;
        }
    }
}