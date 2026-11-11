using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogo.Api.Models;

public class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string SKU { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public string Estado { get; set; } = "Activo";

    public int IdCategoria { get; set; }

    [ForeignKey("IdCategoria")]
    public Categoria? Categoria { get; set; }

    public int IdMarca { get; set; }

    [ForeignKey("IdMarca")]
    public Marca? Marca { get; set; }
}