using System.ComponentModel.DataAnnotations;

namespace Inventario.Api.Models
{
    public class ReservaStock
    {
        [Key]
        public int IdReserva { get; set; }

        [Required(ErrorMessage = "El IdPedido es obligatorio")]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "El IdProducto es obligatorio")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 10000, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int CantidadReservada { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20)]
        public string Estado { get; set; } = "Reservado";
    }
}