using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Data;
using Catalogo.Api.Models;

namespace Catalogo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarcasController : ControllerBase
{
    private readonly CatalogoDbContext _context;
    public MarcasController(CatalogoDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Marca>>> GetAll()
        => await _context.Marcas.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Marca>> GetById(int id)
    {
        var m = await _context.Marcas.FindAsync(id);
        if (m == null) return NotFound(new { mensaje = "Marca no encontrada" });
        return m;
    }

    [HttpPost]
    public async Task<ActionResult<Marca>> Create(Marca marca)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Marcas.Add(marca);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = marca.IdMarca }, marca);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Marca marca)
    {
        if (id != marca.IdMarca) return BadRequest();
        _context.Entry(marca).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var m = await _context.Marcas.FindAsync(id);
        if (m == null) return NotFound();
        _context.Marcas.Remove(m);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}