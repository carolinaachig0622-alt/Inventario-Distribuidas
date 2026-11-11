using System.ComponentModel.DataAnnotations;

namespace Catalogo.Api.Models;

public class Categoria
{
    [Key] public int IdCategoria { get; set; }
    [Required, StringLength(100)] public string Nombre { get; set; } = "";
    [StringLength(250)] public string? Descripcion { get; set; }
    public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}