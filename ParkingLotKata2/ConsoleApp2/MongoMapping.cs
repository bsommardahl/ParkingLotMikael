using MongoDB.Bson.Serialization;
using ParkingLotKata2;

namespace ConsoleApp1
{
    public static class MongoMapping
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Car>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.License);
            });

            BsonClassMap.RegisterClassMap<Bus>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.License);
            });

            BsonClassMap.RegisterClassMap<MotorCycle>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.License);
            });

            BsonClassMap.RegisterClassMap<Helicopter>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.License);
            });
        }
    }
}