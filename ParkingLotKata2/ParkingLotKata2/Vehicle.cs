using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace ParkingLotKata2
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(Guid id, IDriver driver, string license)
        {
            Driver = driver;
            License = license;

        }

        public Guid Id { get; set; }
        public IDriver Driver { get; }
        public abstract double Length { get; }
        public string License { get; private set; }

    }
}