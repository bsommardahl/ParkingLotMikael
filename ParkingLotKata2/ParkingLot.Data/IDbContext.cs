using MongoDB.Driver;

namespace ParkingLot.Data
{
    public interface IDbContext
    {
        IMongoCollection<T> DbSet<T>();
    }
}