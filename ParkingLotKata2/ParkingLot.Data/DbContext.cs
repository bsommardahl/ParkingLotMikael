using MongoDB.Driver;

namespace ParkingLot.Data
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database;


        public DbContext(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> DbSet<T>()
        {
            var table = typeof(T).Name;
            return _database.GetCollection<T>(table);
        }
    }
}