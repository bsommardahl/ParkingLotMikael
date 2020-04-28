using System;
using System.Collections.Generic;
using System.Linq;
using ParkingLotKata2;

namespace TestProject1
{
    public class FakeRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly List<Vehicle> _vehicles;

        public FakeRepository()

        {
            _vehicles = new List<Vehicle>();
        }

        public IEnumerable<T> Get()
        {
            return (IEnumerable<T>)_vehicles;
        }

        public T Get(string id)
        {
            var vehicle= _vehicles.FirstOrDefault(x => x.License == id);
            return vehicle as T;
        }

        public T Create(T item)
        {
            _vehicles.Add(item as Vehicle);
            return item;
        }

        public void Update(string id, T newItem)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            _vehicles.Remove(item as Vehicle);
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