using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agrotienda_2.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrotienda_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly DbContext _context;

        public VentaController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Set<Venta>().Include(v => v.Usuario).ToListAsync();
        }

        // GET: api/Venta/{id}
        [HttpGet("{id}")]
         public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _context.Set<Venta>().Include(v => v.Usuario).FirstOrDefaultAsync(v => v.VentaId == id);

            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }

        // POST: api/Venta
        [HttpPost]
        public async Task<ActionResult<Venta>> CreateVenta(Venta venta)
        {
            if (!_context.Set<Usuario>().Any(u => u.UsuarioId == venta.UsuarioId))
            {
                return BadRequest("UsuarioId no válido");
            }

            _context.Set<Venta>().Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVenta), new { id = venta.VentaId }, venta);
        }

        // PUT: api/Venta/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenta(int id, Venta venta)
        {
            if (id != venta.VentaId)
            {
                return BadRequest("El ID de la venta no coincide.");
            }

            if (!_context.Set<Usuario>().Any(u => u.UsuarioId == venta.UsuarioId))
            {
                return BadRequest("UsuarioId no válido");
            }

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
                {
                    return NotFound();
                }
                else
                 {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Venta/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await _context.Set<Venta>().FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Set<Venta>().Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return _context.Set<Venta>().Any(e => e.VentaId == id);
        }
    }
    }