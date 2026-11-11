using System.ComponentModel.DataAnnotations;
namespace Inventario.Api.Models
{
    public class Bodega
    {
        [Key]
        public int IdBodega { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }
    }
}