using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Data;
using Pedidos.Api.Models;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidoController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public DetallesPedidoController(PedidosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetalles()
        {
            return await _context.DetallesPedido.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetalle(int id)
        {
            var detalle = await _context.DetallesPedido.FindAsync(id);
            if (detalle == null) return NotFound();
            return detalle;
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetalle(DetallePedido detalle)
        {
            _context.DetallesPedido.Add(detalle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetalle), new { id = detalle.IdDetalle }, detalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(int id, DetallePedido detalle)
        {
            if (id != detalle.IdDetalle) return BadRequest();
            _context.Entry(detalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle(int id)
        {
            var detalle = await _context.DetallesPedido.FindAsync(id);
            if (detalle == null) return NotFound();
            _context.DetallesPedido.Remove(detalle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}