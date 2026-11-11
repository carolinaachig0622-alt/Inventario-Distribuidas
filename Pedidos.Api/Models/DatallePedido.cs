using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Api.Models
{
    public class DetallePedido
    {
        [Key]
        public int IdDetalle { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        public Pedido? Pedido { get; set; }

        public int IdProducto { get; set; }
    }
}