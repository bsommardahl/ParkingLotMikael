using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLotKata2
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> Get();
        T Get(string id);
        T Add(T item);
        void Update(string id, T newItem);
        void Remove(T removeItem);
        void Remove(string id);
        IQueryable<T> Query();

    }

}
