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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChats()
        {
            return await _context.Set<Chat>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
            var chat = await _context.Set<Chat>().FindAsync(id);
            return chat == null ? NotFound() : Ok(chat);
        }

        [HttpPost]
        public async Task<ActionResult<Chat>> CreateChat(Chat chat)
        {
            if (!_context.Set<Usuario>().Any(u => u.UsuarioId == chat.UsuarioId))
                return BadRequest("Usuario no encontrado");

            _context.Add(chat);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChat), new { id = chat.ChatId }, chat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChat(int id, Chat chat)
        {
            if (id != chat.ChatId) return BadRequest();

            if (!_context.Set<Usuario>().Any(u => u.UsuarioId == chat.UsuarioId))
                return BadRequest();

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            var chat = await _context.Set<Chat>().FindAsync(id);
            if (chat == null) return NotFound();

            _context.Remove(chat);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ChatExists(int id) => _context.Set<Chat>().Any(c => c.ChatId == id);
    }
}
