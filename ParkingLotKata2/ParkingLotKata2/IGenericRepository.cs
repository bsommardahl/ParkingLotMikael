using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingLotKata2
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(string id);
        Task<T> Add(T item);
        Task Update(string id, T newItem);
        Task<T> Remove(T removeItem);
        Task<T> Remove(string id);

    }

}
