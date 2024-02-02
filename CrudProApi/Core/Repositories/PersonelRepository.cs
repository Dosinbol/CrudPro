using CrudProApi.Data;
using CrudProApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudProApi.Core.Repositories
{
    public class PersonelRepository : GenericRepository<Personel>, IPersonelRepository
    {
        public PersonelRepository(ProjectContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<Personel> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Personels.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public override async Task<IEnumerable<Personel>> AllAsync()
        {
            try
            {
                return await _context.Personels.Where(a => a.Id < 100).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Personel> GetByName(string name)
        {
            try
            {
                return await _context.Personels.FirstOrDefaultAsync(a => a.Name == name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
