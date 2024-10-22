using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Red_de_Esperanza.Models;

namespace Web_Red_de_Esperanza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class desaparecidosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public desaparecidosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/desaparecidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<desaparecidos>>> Getdesaparecidos()
        {
            return await _context.desaparecidos.ToListAsync();
        }

        // GET: api/desaparecidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<desaparecidos>> Getdesaparecidos(int id)
        {
            var desaparecidos = await _context.desaparecidos.FindAsync(id);

            if (desaparecidos == null)
            {
                return NotFound();
            }

            return desaparecidos;
        }

        // PUT: api/desaparecidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdesaparecidos(int id, desaparecidos desaparecidos)
        {
            if (id != desaparecidos.Id_publicacion)
            {
                return BadRequest();
            }

            _context.Entry(desaparecidos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!desaparecidosExists(id))
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

        // POST: api/desaparecidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<desaparecidos>> Postdesaparecidos(desaparecidos desaparecidos)
        {
            _context.desaparecidos.Add(desaparecidos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdesaparecidos", new { id = desaparecidos.Id_publicacion }, desaparecidos);
        }

        // DELETE: api/desaparecidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletedesaparecidos(int id)
        {
            var desaparecidos = await _context.desaparecidos.FindAsync(id);
            if (desaparecidos == null)
            {
                return NotFound();
            }

            _context.desaparecidos.Remove(desaparecidos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool desaparecidosExists(int id)
        {
            return _context.desaparecidos.Any(e => e.Id_publicacion == id);
        }
    }
}
