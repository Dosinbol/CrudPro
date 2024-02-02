using CrudProApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudProApi.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) :base(options)
        {
            
        }
        public DbSet<Personel> Personels { get; set; }
    }
}
