using System;
using System.Collections.Generic;
using System.Reactive.Linq;
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

            // Here, let's subscribe to the event on the Parking Lot so that we can deal with Vehicles
            // as they are checked. Alert the console when a vehicle has exceeded $x in amount owed.

            var vehicleChecked = Observable.FromEventPattern<RobotCheckEventArgType>(
                x => sut.VehicleChecked += x,
                x => sut.VehicleChecked -= x);

            vehicleChecked
                .Select(x => x.EventArgs)
                .Where(x => x.AmountOwed > 15)
                .Subscribe(x =>
                {
                    Console.WriteLine(
                        $"Vehicle with license {x.Vehicle.License} has exceeded the limit. Amount is {x.AmountOwed}.");
                }, exception =>
                {
                    
                    Console.WriteLine($"There was an exception: {exception.Message}");
                    //for some reason, this exception is never caught
                }, () =>
                {
                    Console.WriteLine("Completed.");
                });

            // Async/await is perfect for an eventual call that has one-time output.
            // Rx is ideal for things with multiple eventual responses over time. 

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