using Microsoft.EntityFrameworkCore;
using Inventario.Api.Models;
namespace Inventario.Api.Data
{
    public class InventarioDbContext : DbContext
    {
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options) { }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Existencia> Existencias { get; set; }
        public DbSet<MovimientoInv> MovimientoInv { get; set; }
        public DbSet<ReservaStock> ReservasStock { get; set; }
    }
}