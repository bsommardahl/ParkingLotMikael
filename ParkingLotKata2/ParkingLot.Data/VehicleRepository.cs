using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ParkingLotKata2;

namespace ParkingLot.Data
{
    public class VehicleRepository<T> : IGenericRepository<T> where T : IVehicle
    {
        readonly IMongoCollection<T> _items;

        public VehicleRepository(IDbContext context)
        {
            _items = context.DbSet<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            var cursor = await _items.FindAsync(item => true);
            return cursor.ToList();
        }

        public T Get(string id)
        {
            var vehicle = default(T);
            while (vehicle == null)
            {
                var task = _items.FindAsync(item => item.License == id);
                if (task.Result != null)
                {
                    vehicle = task.Result.First();
                }
            }
            return vehicle;
        }


        public T Add(T item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, T newItem)
        {
            _items.ReplaceOne(item => item.License == id, newItem);
        }

        public void Remove(T removeItem)
        {
            _items.DeleteOne(item => item.License == removeItem.License);
        }

        public void Remove(string id)
        {
            _items.DeleteOne(item => item.License == id);
        }

        public IQueryable<T> Query()
        {
            return _items.AsQueryable();
        }
    }
}