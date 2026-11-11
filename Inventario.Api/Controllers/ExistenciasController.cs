using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.Api.Data;
using Inventario.Api.Models;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExistenciasController : ControllerBase
    {
        private readonly InventarioDbContext _context;
        public ExistenciasController(InventarioDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Existencia>>> GetExistencias()
            => await _context.Existencias.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Existencia>> GetExistencia(int id)
        {
            var e = await _context.Existencias.FindAsync(id);
            if (e == null) return NotFound();
            return e;
        }

        [HttpPost]
        public async Task<ActionResult<Existencia>> PostExistencia(Existencia existencia)
        {
            _context.Existencias.Add(existencia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExistencia), new { id = existencia.IdExistencia }, existencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExistencia(int id, Existencia existencia)
        {
            if (id != existencia.IdExistencia) return BadRequest();
            _context.Entry(existencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistencia(int id)
        {
            var e = await _context.Existencias.FindAsync(id);
            if (e == null) return NotFound();
            _context.Existencias.Remove(e);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}