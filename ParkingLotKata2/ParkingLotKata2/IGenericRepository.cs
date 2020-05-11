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
        Task Remove(T removeItem);
        Task Remove(string id);

    }

}
