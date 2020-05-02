﻿using System;
using System.Collections.Generic;
using ParkingLot.Data;
using ParkingLotKata2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            var dbSettings = new DatabaseSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString"),
                DatabaseName = Environment.GetEnvironmentVariable("DatabaseName"),
                CollectionName = Environment.GetEnvironmentVariable("CollectionName")
            };
            var context = new DbContext(dbSettings);
            var repository = new VehicleRepository<IVehicle>(context);

            MongoMapping.Map();

            var sut = new ParkingLotKata2.ParkingLot(100, new LongTermDiscounter(), new VehicleCostWithdrawalStrategyFactory(
                new List<IVehicleCostCalculationStrategy>
                {
                    new BusCostCalculationStrategy(), new CarCostCalculationStrategy(),
                    new HelicopterCostCalculationStrategy(), new ElectricCarCostCalculationStrategy(),
                    new MotorCycleCostCalculationStrategy()
                }), new CalculateSpaces(2), new LicenseVerifier(), repository);

            var driver = new Driver();

            while (true)
            {
                try
                {
                    Console.WriteLine("Park or Unpark, AddMoney, list?");
                    var action = Console.ReadLine();


                    if (string.IsNullOrEmpty(action)) continue;
                    if (action.ToUpper().Contains("P"))
                    {
                        Console.WriteLine("parking, license number?");
                        var licenseNumber = Console.ReadLine();
                        var car = new Car(driver, licenseNumber);
                        sut.ParkVehicle(car);
                    }
                    else if (action.ToUpper().Contains("A"))
                    {
                        Console.WriteLine("adding money, amount?");
                        var amount = Convert.ToInt32(Console.ReadLine());
                        driver.AddToWallet(amount);
                    }
                    else if (action.ToUpper().Contains("L"))
                    {
                        foreach (var vehicle in repository.Get())
                        {
                            Console.WriteLine(vehicle.License);
                        }
                    }
                    else
                    {
                        Console.WriteLine("unparking, license number?");
                        var licenseNumber = Console.ReadLine();
                        sut.UnparkVehicle(licenseNumber, 1);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}