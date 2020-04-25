using System.Collections.Generic;
using FluentAssertions;
using ParkingLotKata2;

namespace TestProject1
{
    public abstract class given_an_integrated_parking_lot
    {
        protected ParkingLot sut;

        protected given_an_integrated_parking_lot()
        {
            //Arrange
            sut = new ParkingLot(100, new LongTermDiscounter(), new VehicleCostWithdrawalStrategyFactory(
                new List<IVehicleCostCalculationStrategy>
                {
                    new BusCostCalculationStrategy(), new CarCostCalculationStrategy(),
                    new HelicopterCostCalculationStrategy(), new ElectricCarCostCalculationStrategy(),
                    new MotorCycleCostCalculationStrategy()
                }), new CalculateSpaces(2), new FakeLicenseVerifier());
        }
    }

    public class FakeLicenseVerifier : ILicenseVerifier
    {
        public bool IsInvalid(string vehicleLicense)
        {
            var firstChar = vehicleLicense[0];
            var isInt = int.TryParse(firstChar.ToString(), out var firstNum);
            if (!isInt)
            {
                return false;
            }
            return firstNum % 2 > 0;
        }
    }
}
