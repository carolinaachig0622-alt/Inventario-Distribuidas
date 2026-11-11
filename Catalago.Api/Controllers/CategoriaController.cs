using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Data;
using Catalogo.Api.Models;

namespace Catalogo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly CatalogoDbContext _context;
    public CategoriasController(CatalogoDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetAll()
        => await _context.Categorias.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetById(int id)
    {
        var c = await _context.Categorias.FindAsync(id);
        if (c == null) return NotFound(new { mensaje = "Categoria no encontrada" });
        return c;
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Create(Categoria categoria)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = categoria.IdCategoria }, categoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Categoria categoria)
    {
        if (id != categoria.IdCategoria) return BadRequest();
        _context.Entry(categoria).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var c = await _context.Categorias.FindAsync(id);
        if (c == null) return NotFound();
        _context.Categorias.Remove(c);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}