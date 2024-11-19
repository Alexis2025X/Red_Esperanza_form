using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Red_de_Esperanza.Models;

namespace Web_Red_de_Esperanza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesaparecidosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DesaparecidosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/desaparecidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetDesaparecidos()
        {
            return await _context.desaparecidos
                .Include(d => d.Distrito) // Carga la relación con Distrito
                .Include(d => d.Cuenta)  // Carga la relación con Cuentas
                .Select(d => new
                {
                    d.Id_publicacionDesa,
                    d.Nombre,
                    d.Apellido,
                    d.Edad,
                    d.Fecha_Desaparicion,
                    d.Lugar_Desaparicion,
                    d.Descripción_persona,
                    d.Telefono,
                    d.WhatsApp,
                    Distrito = d.Distrito.nombre_distrito, // Nombre del distrito
                    Cuenta = d.Cuenta.Nombre,              // Nombre de la cuenta
                    d.Fecha_publicacion
                })
                .ToListAsync();
        }

        // GET: api/Desaparecidos/buscar
        [HttpGet("{buscar}")]
        public async Task<ActionResult<IEnumerable<Desaparecidos>>> BuscarDesaparecidos(string buscar)
        {
            var consulta = _context.desaparecidos.AsQueryable();
            if (!string.IsNullOrEmpty(buscar))
            {
                consulta = consulta.Where(d => d.Nombre.Contains(buscar) || d.Apellido.Contains(buscar));
            }

            return await consulta.ToListAsync();
        }

        // POST: api/desaparecidos
        [HttpPost]
        public async Task<ActionResult> PostDesaparecidos(Desaparecidos desaparecidos)
        {
            // Validación de campos obligatorios
            if (desaparecidos.id_cuenta == 0 || desaparecidos.id_distrito == 0)
            {
                return BadRequest("Los campos 'id_cuenta' e 'id_distrito' son obligatorios.");
            }

            // Guarda el registro con los datos proporcionados
            var nuevoDesaparecido = new Desaparecidos
            {
                Id_publicacionDesa = desaparecidos.Id_publicacionDesa,
                id_distrito = desaparecidos.id_distrito,
                id_cuenta = desaparecidos.id_cuenta,
                Nombre = desaparecidos.Nombre,
                Apellido = desaparecidos.Apellido,
                Edad = desaparecidos.Edad,
                Fecha_Desaparicion = desaparecidos.Fecha_Desaparicion,
                Lugar_Desaparicion = desaparecidos.Lugar_Desaparicion,
                Descripción_persona = desaparecidos.Descripción_persona,
                Telefono = desaparecidos.Telefono,
                WhatsApp = desaparecidos.WhatsApp,
                Fecha_publicacion = desaparecidos.Fecha_publicacion
            };
            //Id_cuenta
            _context.desaparecidos.Add(nuevoDesaparecido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDesaparecidos), new { id = nuevoDesaparecido.Id_publicacionDesa }, nuevoDesaparecido);
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
                if (!DesaparecidosExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesaparecidos(int id)
        {
            var desaparecidos = await _context.desaparecidos
                .FirstOrDefaultAsync(d => d.Id_publicacionDesa == id); // Sin Include

            if (desaparecidos == null)
            {
                return NotFound(new { mensaje = "No se encontró el registro." });
            }

            _context.desaparecidos.Remove(desaparecidos);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //Cuentaid_cuenta
        private bool DesaparecidosExists(int id)
        {
            return _context.desaparecidos.Any(e => e.Id_publicacionDesa == id);
        }
    }

}
