using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Inventario.Api.Models
{
    public class Existencia
    {
        [Key]
        public int IdExistencia { get; set; }
        [ForeignKey("Bodega")]
        public int IdBodega { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
    }
}