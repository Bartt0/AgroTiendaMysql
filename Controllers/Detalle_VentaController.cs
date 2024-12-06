using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agrotienda_2.data;
using Agrotienda_2.models;

namespace Agrotienda_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_VentaController : ControllerBase
    {
        private readonly Creador_de_TablasContext _context;

        public Detalle_VentaController(Creador_de_TablasContext context)
        {
            _context = context;
        }

        // GET: api/Detalle_Venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle_Venta>>> GetDetalle_de_Ventas()
        {
            return await _context.Detalle_de_Ventas.ToListAsync();
        }

        // GET: api/Detalle_Venta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle_Venta>> GetDetalle_Venta(int id)
        {
            var detalle_Venta = await _context.Detalle_de_Ventas.FindAsync(id);

            if (detalle_Venta == null)
            {
                return NotFound();
            }

            return detalle_Venta;
        }

        // PUT: api/Detalle_Venta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle_Venta(int id, Detalle_Venta detalle_Venta)
        {
            if (id != detalle_Venta.Detalle_VentaId)
            {
                return BadRequest();
            }

            _context.Entry(detalle_Venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Detalle_VentaExists(id))
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

        // POST: api/Detalle_Venta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Detalle_Venta>> PostDetalle_Venta(Detalle_Venta detalle_Venta)
        {
            _context.Detalle_de_Ventas.Add(detalle_Venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle_Venta", new { id = detalle_Venta.Detalle_VentaId }, detalle_Venta);
        }

        // DELETE: api/Detalle_Venta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle_Venta(int id)
        {
            var detalle_Venta = await _context.Detalle_de_Ventas.FindAsync(id);
            if (detalle_Venta == null)
            {
                return NotFound();
            }

            _context.Detalle_de_Ventas.Remove(detalle_Venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Detalle_VentaExists(int id)
        {
            return _context.Detalle_de_Ventas.Any(e => e.Detalle_VentaId == id);
        }
    }
}
