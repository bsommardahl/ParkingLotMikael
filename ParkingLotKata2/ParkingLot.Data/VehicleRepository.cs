using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ParkingLotKata2;

namespace ParkingLot.Data
{
    public class VehicleRepository<T> : IGenericRepository<T> where T : class, IVehicle
    {
        private readonly IMongoCollection<Vehicle> _items;

        public VehicleRepository(IDbContext context)
        {
            _items = context.DbSet<Vehicle>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            var cursor = await _items.FindAsync(item => true);
            return (IEnumerable<T>)cursor.ToList();
        }

        public async Task<T> Get(string license)
        {

            var vehicle = await _items.Find(x => x.License == license).FirstOrDefaultAsync();
            return vehicle as T;
        }


        public async Task<T> Add(T item)
        {
            await _items.InsertOneAsync(item as Vehicle);
            return item;
        }

        public async Task Update(string id, T newItem)
        {
            await _items.ReplaceOneAsync(item => item.License == id, newItem as Vehicle);
        }

        public async Task<T> Remove(T removeItem)
        {
            var vehicle = await _items.FindOneAndDeleteAsync(item => item.License == removeItem.License);
            return vehicle as T;
        }

        public async Task<T> Remove(string id)
        {

            var vehicle = await _items.FindOneAndDeleteAsync(item => item.License == id);
            return vehicle as T;
        }
    }
}