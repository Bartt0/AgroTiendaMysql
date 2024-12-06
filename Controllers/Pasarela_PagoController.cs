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
    public class Pasarela_PagoController : ControllerBase
    {
        private readonly Creador_de_TablasContext _context;

        public Pasarela_PagoController(Creador_de_TablasContext context)
        {
            _context = context;
        }

        // GET: api/Pasarela_Pago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasarela_Pago>>> GetPasarela_de_Pagos()
        {
            return await _context.Pasarela_de_Pagos.ToListAsync();
        }

        // GET: api/Pasarela_Pago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pasarela_Pago>> GetPasarela_Pago(int id)
        {
            var pasarela_Pago = await _context.Pasarela_de_Pagos.FindAsync(id);

            if (pasarela_Pago == null)
            {
                return NotFound();
            }

            return pasarela_Pago;
        }

        // PUT: api/Pasarela_Pago/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasarela_Pago(int id, Pasarela_Pago pasarela_Pago)
        {
            if (id != pasarela_Pago.Pasarela_PagoId)
            {
                return BadRequest();
            }

            _context.Entry(pasarela_Pago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pasarela_PagoExists(id))
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

        // POST: api/Pasarela_Pago
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pasarela_Pago>> PostPasarela_Pago(Pasarela_Pago pasarela_Pago)
        {
            _context.Pasarela_de_Pagos.Add(pasarela_Pago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasarela_Pago", new { id = pasarela_Pago.Pasarela_PagoId }, pasarela_Pago);
        }

        // DELETE: api/Pasarela_Pago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasarela_Pago(int id)
        {
            var pasarela_Pago = await _context.Pasarela_de_Pagos.FindAsync(id);
            if (pasarela_Pago == null)
            {
                return NotFound();
            }

            _context.Pasarela_de_Pagos.Remove(pasarela_Pago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Pasarela_PagoExists(int id)
        {
            return _context.Pasarela_de_Pagos.Any(e => e.Pasarela_PagoId == id);
        }
    }
}
