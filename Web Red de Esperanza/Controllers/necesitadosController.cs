﻿using System;
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
        public async Task<ActionResult<IEnumerable<Necesitados>>> Getnecesitados()
        {
            return await _context.necesitado.ToListAsync();
        }

        // GET: api/necesitados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Necesitados>> Getnecesitados(int id)
        {
            var necesitados = await _context.necesitado.FindAsync(id);

            if (necesitados == null)
            {
                return NotFound();
            }

            return necesitados;
        }

        // PUT: api/necesitados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnecesitados(int id, Necesitados necesitados)
        {
            if (id != necesitados.Id_publicacion)
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
        public async Task<ActionResult<Necesitados>> Postnecesitados(Necesitados necesitados)
        {
            _context.necesitado.Add(necesitados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnecesitados", new { id = necesitados.Id_publicacion }, necesitados);
        }

        // DELETE: api/necesitados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletenecesitados(int id)
        {
            var necesitados = await _context.necesitado.FindAsync(id);
            if (necesitados == null)
            {
                return NotFound();
            }

            _context.necesitado.Remove(necesitados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool necesitadosExists(int id)
        {
            return _context.necesitado.Any(e => e.Id_publicacion == id);
        }
    }
}