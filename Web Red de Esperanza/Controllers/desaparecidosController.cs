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
        public async Task<ActionResult<IEnumerable<Desaparecidos>>> Getdesaparecidos()
        {

            return await _context.desaparecidos.Include(m => m.cuenta).ToListAsync();

           // return await _context.desaparecidos.ToListAsync();
        }

        //GET: api/Desaparecidos/buscar
        [HttpGet("{buscar}")]
        public async Task<ActionResult<IEnumerable<Desaparecidos>>> BuscarDesaparecidos(string buscar)
        {
            var consulta = _context.desaparecidos.Include(m => m.cuenta).AsQueryable();
            if (buscar != "")
            {
                consulta = consulta.Where(d => d.Nombre.Contains(buscar));
            }
            /*if (buscar != "")
            {
                consulta = consulta.Where(d => d.Apellido.Contains(buscar));
            }*/
            return await consulta.ToListAsync();
        }


        // PUT: api/desaparecidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdesaparecidos(int id, Desaparecidos desaparecidos)
        {
            if (id != desaparecidos.Id_publicacionDesa)
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
        public async Task<ActionResult<Desaparecidos>> Postdesaparecidos(Desaparecidos desaparecidos)
        {
            _context.desaparecidos.Add(desaparecidos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdesaparecidos", new { id = desaparecidos.Id_publicacionDesa }, desaparecidos);
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
            return _context.desaparecidos.Any(e => e.Id_publicacionDesa == id);
        }
    }
}
