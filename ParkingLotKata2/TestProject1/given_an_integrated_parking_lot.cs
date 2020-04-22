using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

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
            return false;
        }
    }

    public class when_validating_the_fake_license_verifier_against_the_real
    {
        [Fact]
        public void should_behave_the_same()
        {
            //Arrange
            var suts = new List<ILicenseVerifier>
            {
                new FakeLicenseVerifier(),
                new LicenseVerifier()
            };
            
            //Act
            var results = suts.Select(x => x.IsInvalid("123"));

            //Assert
            results.Should().AllBeEquivalentTo(true);
        }

    }
}