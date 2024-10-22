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
    public class cuentasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public cuentasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/cuentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cuentas>>> Getcuentas()
        {
            return await _context.cuentas.ToListAsync();
        }

        // GET: api/cuentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cuentas>> Getcuentas(int id)
        {
            var cuentas = await _context.cuentas.FindAsync(id);

            if (cuentas == null)
            {
                return NotFound();
            }

            return cuentas;
        }

        // PUT: api/cuentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcuentas(int id, cuentas cuentas)
        {
            if (id != cuentas.Id_cuenta)
            {
                return BadRequest();
            }

            _context.Entry(cuentas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cuentasExists(id))
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

        // POST: api/cuentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<cuentas>> Postcuentas(cuentas cuentas)
        {
            _context.cuentas.Add(cuentas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcuentas", new { id = cuentas.Id_cuenta }, cuentas);
        }

        // DELETE: api/cuentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecuentas(int id)
        {
            var cuentas = await _context.cuentas.FindAsync(id);
            if (cuentas == null)
            {
                return NotFound();
            }

            _context.cuentas.Remove(cuentas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool cuentasExists(int id)
        {
            return _context.cuentas.Any(e => e.Id_cuenta == id);
        }
    }
}
