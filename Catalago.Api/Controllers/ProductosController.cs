using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Data;
using Catalogo.Api.Models;

namespace Catalogo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly CatalogoDbContext _context;
    public ProductosController(CatalogoDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        => await _context.Productos.Include(p => p.Categoria).Include(p => p.Marca).ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetById(int id)
    {
        var p = await _context.Productos.FindAsync(id);
        if (p == null) return NotFound(new { mensaje = "Producto no encontrado" });
        return p;
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> Create(Producto producto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (!await _context.Categorias.AnyAsync(c => c.IdCategoria == producto.IdCategoria))
            return BadRequest(new { mensaje = "La categoria no existe" });
        if (!await _context.Marcas.AnyAsync(m => m.IdMarca == producto.IdMarca))
            return BadRequest(new { mensaje = "La marca no existe" });

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = producto.IdProducto }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Producto producto)
    {
        if (id != producto.IdProducto) return BadRequest();
        _context.Entry(producto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _context.Productos.FindAsync(id);
        if (p == null) return NotFound();
        _context.Productos.Remove(p);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}