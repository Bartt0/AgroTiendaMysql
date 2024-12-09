using Agrotienda_2.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agrotienda_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly DbContext _context;

        public ChatController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Chat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChats()
        {
            return await _context.Set<Chat>()
                                 .Include(c => c.Usuario)
                                 .ToListAsync();
        }

        // GET: api/Chat/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
            var chat = await _context.Set<Chat>()
                                     .Include(c => c.Usuario)
                                     .FirstOrDefaultAsync(c => c.ChatId == id);

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        // POST: api/Chat
        [HttpPost]
        public async Task<ActionResult<Chat>> CreateChat(Chat chat)
        {
            if (!_context.Set<Usuario>().Any(u => u.UsuarioId == chat.UsuarioId))
            {
                return BadRequest("UsuarioId no válido");
            }

            _context.Set<Chat>().Add(chat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChat), new { id = chat.ChatId }, chat);
        }

        // PUT: api/Chat/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChat(int id, Chat chat)
        {
            if (id != chat.ChatId)
            {
                return BadRequest("El ID del chat no coincide.");
            }

            if (!_context.Set<Usuario>().Any(u => u.UsuarioId == chat.UsuarioId))
            {
                return BadRequest("UsuarioId no válido");
            }

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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

        // DELETE: api/Chat/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            var chat = await _context.Set<Chat>().FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            _context.Set<Chat>().Remove(chat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatExists(int id)
        {
            return _context.Set<Chat>().Any(e => e.ChatId == id);
        }
    }
}
