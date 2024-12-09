using Microsoft.AspNetCore.Mvc;
using Agrotienda_2.models; // Asegúrate de que tienes la clase Producto en el espacio de nombres correcto
using Microsoft.EntityFrameworkCore;
using Agrotienda_2.data;

namespace Agrotienda_2.Controllers


{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly Creador_de_TablasContext _context;

        public CarritoController(Creador_de_TablasContext context)
        {
            _context = context;
        }

        // GET: api/carrito
        [HttpGet]
        public async Task<IActionResult> ObtenerCarritos()
        {
            var carritos = await _context.Carrito.Include(c => c.Usuario).ToListAsync();
            return Ok(carritos);
        }

        // GET: api/carrito/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCarritoPorId(int id)
        {
            var carrito = await _context.Carrito
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.CarritoId == id);

            if (carrito == null)
            {
                return NotFound("Carrito no encontrado.");
            }

            return Ok(carrito);
        }

        // POST: api/carrito
        [HttpPost]
        public async Task<IActionResult> CrearCarrito([FromBody] Carrito carrito)
        {
            if (carrito == null)
            {
                return BadRequest("El carrito no puede ser nulo.");
            }

            carrito.Fecha_Creacion = DateTime.Now; // Asignar la fecha de creación automáticamente

            _context.Carrito.Add(carrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerCarritoPorId), new { id = carrito.CarritoId }, carrito);
        }

        // DELETE: api/carrito/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCarrito(int id)
        {
            var carrito = await _context.Carrito.FindAsync(id);
            if (carrito == null)
            {
                return NotFound("Carrito no encontrado.");
            }

            _context.Carrito.Remove(carrito);
            await _context.SaveChangesAsync();

            return Ok("Carrito eliminado correctamente.");
        }
    }
}