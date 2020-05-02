using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using ParkingLotKata2;

namespace ParkingLot.Data
{
    public class VehicleRepository<T> : IGenericRepository<T> where T : IVehicle
    {
        private readonly IMongoCollection<T> _items;

        public VehicleRepository(IDbContext context)
        {
            _items = context.DbSet<T>();
        }

        public IEnumerable<T> Get() =>
            _items.Find(item => true).ToList();

        public T Get(string id) =>
            _items.Find(item => item.License == id).FirstOrDefault();


        public T Add(T item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, T newItem) =>
            _items.ReplaceOne(item => item.License == id, newItem);

        public void Remove(T removeItem) =>
            _items.DeleteOne(item => item.License == removeItem.License);

        public void Remove(string id) =>
            _items.DeleteOne(item => item.License == id);

        public IQueryable<T> Query()
        {
            return _items.AsQueryable();
        }
    }
}