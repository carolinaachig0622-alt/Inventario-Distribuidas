using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Inventario.Api.Models
{
    public class MovimientoInv
    {
        [Key]
        public int IdMovimientoInv { get; set; }
        [ForeignKey("Bodega")]
        public int IdBodega { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string? Tipo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}