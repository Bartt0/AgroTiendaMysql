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
    public class Detalle_CarritoController : ControllerBase
    {
        private readonly Creador_de_TablasContext _context;

        public Detalle_CarritoController(Creador_de_TablasContext context)
        {
            _context = context;
        }

        // GET: api/Detalle_Carrito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle_Carrito>>> GetDetalle_de_Carrito()
        {
            return await _context.Detalle_de_Carrito.ToListAsync();
        }

        // GET: api/Detalle_Carrito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle_Carrito>> GetDetalle_Carrito(int id)
        {
            var detalle_Carrito = await _context.Detalle_de_Carrito.FindAsync(id);

            if (detalle_Carrito == null)
            {
                return NotFound();
            }

            return detalle_Carrito;
        }

        // PUT: api/Detalle_Carrito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle_Carrito(int id, Detalle_Carrito detalle_Carrito)
        {
            if (id != detalle_Carrito.Detalle_CarritoId)
            {
                return BadRequest();
            }

            _context.Entry(detalle_Carrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Detalle_CarritoExists(id))
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

        // POST: api/Detalle_Carrito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Detalle_Carrito>> PostDetalle_Carrito(Detalle_Carrito detalle_Carrito)
        {
            _context.Detalle_de_Carrito.Add(detalle_Carrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle_Carrito", new { id = detalle_Carrito.Detalle_CarritoId }, detalle_Carrito);
        }

        // DELETE: api/Detalle_Carrito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle_Carrito(int id)
        {
            var detalle_Carrito = await _context.Detalle_de_Carrito.FindAsync(id);
            if (detalle_Carrito == null)
            {
                return NotFound();
            }

            _context.Detalle_de_Carrito.Remove(detalle_Carrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Detalle_CarritoExists(int id)
        {
            return _context.Detalle_de_Carrito.Any(e => e.Detalle_CarritoId == id);
        }
    }
}