using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.Api.Data;
using Inventario.Api.Models;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoInvController : ControllerBase
    {
        private readonly InventarioDbContext _context;
        public MovimientoInvController(InventarioDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoInv>>> GetMovimientos()
            => await _context.MovimientoInv.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoInv>> GetMovimiento(int id)
        {
            var m = await _context.MovimientoInv.FindAsync(id);
            if (m == null) return NotFound();
            return m;
        }

        [HttpPost]
        public async Task<ActionResult<MovimientoInv>> PostMovimiento(MovimientoInv movimiento)
        {
            _context.MovimientoInv.Add(movimiento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovimiento), new { id = movimiento.IdMovimientoInv }, movimiento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimiento(int id)
        {
            var m = await _context.MovimientoInv.FindAsync(id);
            if (m == null) return NotFound();
            _context.MovimientoInv.Remove(m);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}