using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ParkingLotKata2;

namespace ParkingLot.Data
{
    public class VehicleRepository<T> : IGenericRepository<T> where T : Vehicle
    {
        private readonly IMongoCollection<T> _items;

        public VehicleRepository(IDbContext context)
        {
            _items = context.DbSet<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            var cursor = await _items.FindAsync(item => true);
            return cursor.ToList();
        }

        public async Task<T> Get(string license)
        {
            var vehicle = await _items.Find(x => x.License == license).FirstOrDefaultAsync();
            return vehicle;
        }

        public async Task<T> Add(T item)
        {
            await _items.InsertOneAsync(item);
            return item;
        }

        public async Task Update(string id, T newItem)
        {
            await _items.ReplaceOneAsync(item => item.License == id, newItem);
        }

        public async Task Remove(T removeItem)
        {
            await _items.FindOneAndDeleteAsync(item => item.License == removeItem.License);

        }

        public async Task Remove(string id)
        {

            await _items.FindOneAndDeleteAsync(item => item.License == id);

        }
    }
}