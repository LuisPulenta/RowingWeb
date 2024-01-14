using Microsoft.EntityFrameworkCore;
using RowingWeb.Shared.Entities;

namespace RowingWeb.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<ObrasDocumento> ObrasDocumentos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
