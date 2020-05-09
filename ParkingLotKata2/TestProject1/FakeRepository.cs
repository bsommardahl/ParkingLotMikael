using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingLotKata2;

namespace TestProject1
{
    public class FakeRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly List<Vehicle> Vehicles;

        public FakeRepository()

        {
            Vehicles = new List<Vehicle>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return (IEnumerable<T>)Vehicles;
        }

        public T Get(string id)
        {
            var vehicle = Vehicles.FirstOrDefault(x => x.License == id);
            return vehicle as T;
        }

        public T Add(T item)
        {
            Vehicles.Add(item as Vehicle);
            return item;
        }

        public void Update(string id, T newItem)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            Vehicles.Remove(item as Vehicle);
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            throw new NotImplementedException();
        }
    }
}