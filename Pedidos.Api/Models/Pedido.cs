using System.ComponentModel.DataAnnotations;

namespace Pedidos.Api.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }
        public List<DetallePedido> Detalles { get; set; } = new();
    }
}