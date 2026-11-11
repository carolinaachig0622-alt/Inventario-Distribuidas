using System.ComponentModel.DataAnnotations;

namespace Catalogo.Api.Models;

public class Marca
{
    [Key] public int IdMarca { get; set; }
    [Required, StringLength(100)] public string Nombre { get; set; } = "";
    [StringLength(100)] public string? PaisOrigen { get; set; }
    public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}