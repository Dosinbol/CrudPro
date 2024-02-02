using CrudProApi.Models;

namespace CrudProApi.Core
{
    public interface IPersonelRepository : IGenericRepository<Personel>
    {
        Task<Personel> GetByName(string name);
    }
}
