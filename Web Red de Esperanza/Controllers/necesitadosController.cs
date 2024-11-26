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
    public class necesitadosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public necesitadosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/necesitados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Necesitado>>> Getnecesitados()
        {
            return await _context.necesitados.Include(m => m.cuenta).ToListAsync();
           // return await _context.necesitados.ToListAsync();
        }
        //GET: api/Desaparecidos/buscar
        [HttpGet("{buscar}")]
        public async Task<ActionResult<IEnumerable<Necesitado>>> BuscarNecesitados(string buscar)
        {
            var consulta = _context.necesitados.Include(m => m.cuenta).AsQueryable();
            if (buscar != "")
            {
                consulta = consulta.Where(d => d.Nombre_nece.Contains(buscar));
            }
/*            if (buscar != "")
            {
                consulta = consulta.Where(d => d.Apellido.Contains(buscar));
            }*/
            return await consulta.ToListAsync();
        }
        // PUT: api/necesitados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnecesitados(int id, Necesitado necesitados)
        {
            if (id != necesitados.Id_publicacionNese)
            {
                return BadRequest();
            }

            _context.Entry(necesitados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!necesitadosExists(id))
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

        // POST: api/necesitados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Necesitado>> Postnecesitados(Necesitado necesitados)
        {
            _context.necesitados.Add(necesitados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnecesitados", new { id = necesitados.Id_publicacionNese }, necesitados);
        }

        // DELETE: api/necesitados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletenecesitados(int id)
        {
            var necesitados = await _context.necesitados.FindAsync(id);
            if (necesitados == null)
            {
                return NotFound();
            }

            _context.necesitados.Remove(necesitados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool necesitadosExists(int id)
        {
            return _context.necesitados.Any(e => e.Id_publicacionNese == id);
        }
    }
}