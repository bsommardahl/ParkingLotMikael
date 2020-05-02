using MongoDB.Bson.Serialization;
using ParkingLotKata2;

namespace ConsoleApp1
{
    public static class MongoMapping
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Vehicle>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
                cm.MapIdProperty(c => c.License);
                cm.MapMember(c => c.Driver);
            });
            BsonClassMap.RegisterClassMap<Car>(cm =>
            {
                cm.MapCreator(c => new Car(c.Driver, c.License, false));
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