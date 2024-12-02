using Microsoft.AspNetCore.Mvc;
using Agrotienda_2.models;
using Microsoft.EntityFrameworkCore;
using Agrotienda_2.data;

namespace AgroTiendaMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionControllers : ControllerBase
    {
        private readonly Creador_de_TablasContext _context;

        public CalificacionControllers(Creador_de_TablasContext context)
        {
            _context = context;
        }

        // Agregar calificaciones
        [HttpGet]
        public async Task<IActionResult> GetCalificaciones()
        {
            var calificacion = await _context.Calificacion.ToListAsync();
            return Ok(calificacion);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalificacion(int id)
        {
            var calificacion = await _context.Calificacion.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return Ok(calificacion);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCalificacion([FromBody] Calificacion calificacion)
        {
            if (calificacion == null)
            {
                return BadRequest("La calificación no puede ser nula.");
            }

            _context.Calificacion.Add(calificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCalificacion), new { id = calificacion.CalificacionId }, calificacion);
        }
 
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCalificacion(int id, [FromBody] Calificacion calificacion)
        {
            if (id != calificacion.CalificacionId)
            {
                return BadRequest("El ID de la calificación no coincide.");
            }

            _context.Entry(calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Calificacion.Any(e => e.CalificacionId == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCalificacion(int id)
        {
            var calificacion = await _context.Calificacion.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            _context.Calificacion.Remove(calificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}