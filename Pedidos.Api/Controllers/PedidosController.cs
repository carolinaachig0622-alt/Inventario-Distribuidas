using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Data;
using Pedidos.Api.Models;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public PedidosController(PedidosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos
                .Include(p => p.Detalles)
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Detalles)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido == null) return NotFound();
            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            // Evita que EF intente insertar el Pedido padre 2 veces desde Detalle
            foreach (var d in pedido.Detalles)
            {
                d.Pedido = null;
            }

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.IdPedido }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.IdPedido) return BadRequest();

            var existente = await _context.Pedidos.FindAsync(id);
            if (existente == null) return NotFound();

            // Solo actualizamos los campos, no los Detalles, así no da error
            existente.Fecha = pedido.Fecha;
            existente.Total = pedido.Total;
            existente.IdCliente = pedido.IdCliente;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido == null) return NotFound();

            _context.DetallesPedido.RemoveRange(pedido.Detalles);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}