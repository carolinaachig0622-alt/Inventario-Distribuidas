using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.Api.Data;
using Inventario.Api.Models;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly InventarioDbContext _context;
        public BodegasController(InventarioDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodegas()
            => await _context.Bodegas.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Bodega>> GetBodega(int id)
        {
            var b = await _context.Bodegas.FindAsync(id);
            if (b == null) return NotFound();
            return b;
        }

        [HttpPost]
        public async Task<ActionResult<Bodega>> PostBodega(Bodega bodega)
        {
            _context.Bodegas.Add(bodega);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBodega), new { id = bodega.IdBodega }, bodega);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodega(int id, Bodega bodega)
        {
            if (id != bodega.IdBodega) return BadRequest();
            _context.Entry(bodega).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodega(int id)
        {
            var b = await _context.Bodegas.FindAsync(id);
            if (b == null) return NotFound();
            _context.Bodegas.Remove(b);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}