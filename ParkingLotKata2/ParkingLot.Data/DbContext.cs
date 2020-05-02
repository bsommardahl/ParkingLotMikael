using MongoDB.Driver;

namespace ParkingLot.Data
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;


        public DbContext(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _collectionName = settings.CollectionName;
        }

        public IMongoCollection<T> DbSet<T>()
        {
            return _database.GetCollection<T>(_collectionName);
        }
    }
}