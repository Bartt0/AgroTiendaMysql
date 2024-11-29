using Microsoft.AspNetCore.Mvc;
using Agrotienda_2.models; // Asegúrate de que tienes la clase Producto en el espacio de nombres correcto
using Microsoft.EntityFrameworkCore;
using Agrotienda_2.data; // Asegúrate de que el DbContext está correctamente importado

namespace Agrotienda_2.Controllers
{
    // Definir el controlador de productos
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Creador_de_TablasContext _context;

       
        public ProductosController(Creador_de_TablasContext context)
        {
            _context = context;
        }

        // GET: api/productos/obtenerproducto
        [HttpGet("obtenerproducto")]
        public IActionResult ObtenerProducto()
        {
            // Crear un producto 
            var producto = new Producto
            {
                ProductoId = 1,
                Nombre = "Manzana",
                Precio = 10.50m
            };

            return Ok(producto); // Devolver el producto en formato JSON
        }

        // GET: api/productos
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            // Obtener todos los productos desde la base de datos
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        // POST: api/productos
        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerProducto), new { id = producto.ProductoId }, producto);
        }
    }
}
