using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.Api.Data;
using Inventario.Api.Models;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaStockController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ReservaStockController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaStock>>> GetReservas()
        {
            return await _context.ReservasStock.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaStock>> GetReserva(int id)
        {
            var reserva = await _context.ReservasStock.FindAsync(id);
            if (reserva == null) return NotFound();
            return reserva;
        }

        [HttpPost]
        public async Task<ActionResult<ReservaStock>> PostReserva(ReservaStock reserva)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.ReservasStock.Add(reserva);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReserva), new { id = reserva.IdReserva }, reserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, ReservaStock reserva)
        {
            if (id != reserva.IdReserva) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existente = await _context.ReservasStock.FindAsync(id);
            if (existente == null) return NotFound();

            existente.IdPedido = reserva.IdPedido;
            existente.IdProducto = reserva.IdProducto;
            existente.CantidadReservada = reserva.CantidadReservada;
            existente.FechaReserva = reserva.FechaReserva;
            existente.Estado = reserva.Estado;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.ReservasStock.FindAsync(id);
            if (reserva == null) return NotFound();
            _context.ReservasStock.Remove(reserva);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}