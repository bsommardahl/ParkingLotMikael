using System.Collections.Generic;
using System.Linq;

namespace ParkingLotKata2
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> Get();
        T Get(string id);
        T Create(T item);
        void Update(string id, T newItem);
        void Remove(T removeItem);
        void Remove(string id);
        IQueryable<T> Query();

    }

}
