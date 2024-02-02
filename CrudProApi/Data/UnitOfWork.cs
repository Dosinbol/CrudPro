using CrudProApi.Core;
using CrudProApi.Core.Repositories;

namespace CrudProApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ProjectContext _context;
        private readonly ILogger _logger;
        public IPersonelRepository Personel { get; private set; }
        public UnitOfWork(ProjectContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");
            Personel = new PersonelRepository(_context, _logger);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
