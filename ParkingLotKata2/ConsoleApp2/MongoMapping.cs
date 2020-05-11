using System;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using ParkingLotKata2;

namespace ConsoleApp1
{
    public static class MongoMapping
    {
        public static void Map()
        {

            BsonClassMap.RegisterClassMap<Driver>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(x => new Driver(x.Wallet));
            });

            BsonClassMap.RegisterClassMap<Vehicle>(cm =>
            {
                cm.AutoMap();

                cm.MapIdMember(c => c.Id)
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIdGenerator(GuidGenerator.Instance);

                cm.SetIsRootClass(true);
                cm.MapMember(c => c.Driver);
                // cm.MapProperty(c => c.License);

            });

            BsonClassMap.RegisterClassMap<Car>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(c => new Car(c.Id, c.Driver, c.License, c.HasTrumpSticker));
            });

            BsonClassMap.RegisterClassMap<Bus>(cm =>
            {
                cm.MapCreator(b => new Bus(b.Driver, b.License));
            });

            BsonClassMap.RegisterClassMap<MotorCycle>(cm =>
            {
                cm.MapCreator(m => new MotorCycle(m.Driver, m.License));
            });

            BsonClassMap.RegisterClassMap<Helicopter>(cm =>
            {
                cm.MapCreator(h => new Helicopter(h.Driver, h.License));
            });
        }
    }
}