using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp2;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using ParkingLot.Data;
using ParkingLotKata2;
using TestProject1;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DotNetEnv.Env.Load();
            MongoMapping.Map();

            var dbSettings = new DatabaseSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString"),
                DatabaseName = Environment.GetEnvironmentVariable("DatabaseName"),
                CollectionName = Environment.GetEnvironmentVariable("CollectionName")
            };
            var context = new DbContext(dbSettings);
            var repository = new VehicleRepository<Vehicle>(context);
            //var repository = new FakeRepository<Vehicle>();


            var sut = new ParkingLotKata2.ParkingLot(100, new LongTermDiscounter(),
                new VehicleCostWithdrawalStrategyFactory(
                    new List<VehicleCostCalculationStrategy>
                    {
                        new BusCostCalculationStrategy(), new CarCostCalculationStrategy(),
                        new HelicopterCostCalculationStrategy(), new ElectricCarCostCalculationStrategy(),
                        new MotorCycleCostCalculationStrategy()
                    }), new CalculateSpaces(2), new LicenseVerifier(), repository);



            var driver = new Driver();
            driver.AddToWallet(200);

            while (true)
                try
                {
                    Console.WriteLine("Park or Unpark, AddMoney, list?");
                    var action = Console.ReadLine();


                    if (string.IsNullOrEmpty(action)) continue;
                    if (action.ToUpper().Contains("P"))
                    {
                        Console.WriteLine("parking, license number?");
                        var licenseNumber = Console.ReadLine();
                        var car = new Car(Guid.NewGuid(), driver, licenseNumber);
                        await sut.ParkVehicle(car);
                    }
                    else if (action.ToUpper().Contains("A"))
                    {
                        Console.WriteLine("adding money, amount?");
                        var amount = Convert.ToInt32(Console.ReadLine());
                        driver.AddToWallet(amount);
                    }
                    else if (action.ToUpper().Contains("L"))
                    {
                        var enumerable = await repository.Get();
                        foreach (var vehicle in enumerable)
                            Console.WriteLine(vehicle.License);
                    }
                    else
                    {
                        Console.WriteLine("unparking, license number?");
                        var licenseNumber = Console.ReadLine();
                        await sut.UnparkVehicle(licenseNumber, 1);
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