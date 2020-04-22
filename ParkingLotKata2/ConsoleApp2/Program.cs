using System;
using System.Collections.Generic;
using ParkingLotKata2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sut = new ParkingLot(100, new LongTermDiscounter(), new VehicleCostWithdrawalStrategyFactory(
                new List<IVehicleCostCalculationStrategy>
                {
                    new BusCostCalculationStrategy(), new CarCostCalculationStrategy(),
                    new HelicopterCostCalculationStrategy(), new ElectricCarCostCalculationStrategy(),
                    new MotorCycleCostCalculationStrategy()
                }), new CalculateSpaces(2), new LicenseVerifier());

            while (true)
            {
                Console.WriteLine("Park or unpark?");
                var action = Console.ReadLine();
                if (action.ToUpper().Contains("P"))
                {
                    Console.WriteLine("parking, license number?");
                    var licenseNumber = Console.ReadLine();
                    sut.ParkVehicle(new Car(new Driver(), licenseNumber));
                }
                else
                {
                    Console.WriteLine("unparking, license number?");
                    var licenseNumber = Console.ReadLine();
                    sut.UnparkVehicle(licenseNumber, 1);
                }

            }
        }
    }
}