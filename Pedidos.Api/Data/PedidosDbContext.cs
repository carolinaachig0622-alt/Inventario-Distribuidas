using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Models;

namespace Pedidos.Api.Data
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }

        public DbSet<Cliente> Clientes { get; set; }



    }
}
