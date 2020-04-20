using System;
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


        public Func<T, int, double> Create<T>(T vehicle) where T: IVehicle

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
        
        double GetAmountFromStrategy<T>(IVehicleCostCalculationStrategy strategy, T vehicle, int days) where T : IVehicle
        {
            var methodInfo = strategy.GetType().GetMethods().First(x => x.Name == "Execute");
            var amount = methodInfo.Invoke(strategy, new object[] {vehicle, days});
            return (double)amount;
        }
    }
}