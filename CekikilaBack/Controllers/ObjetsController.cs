using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CekikilaBack.Models;
using CekikilaShared.Dto;
using CekikilaBack.Controllers.TypeConverter;


namespace CekikilaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ObjetsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Objets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjetDto>>> GetObjets()
        {
            return await _context.Objets.Select(o => o.ToDto()).ToListAsync();
        }

        // GET: api/Objets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objet>> GetObjet(int id)
        {
            var objet = await _context.Objets.FindAsync(id);

            if (objet == null)
            {
                return NotFound();
            }

            return objet;
        }

        // PUT: api/Objets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjet(int id, Objet objet)
        {
            if (id != objet.IdObjet)
            {
                return BadRequest();
            }

            _context.Entry(objet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetExists(id))
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

        // POST: api/Objets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Objet>> PostObjet(ObjetDto objet)
        {
            // TODO : Valider les données
            try
            {
                _context.Objets.Add(await objet.FromDto(_context));
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetObjet", new { id = objet.IdObjet }, objet);
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Objets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjet(int id)
        {
            var objet = await _context.Objets.FindAsync(id);
            if (objet == null)
            {
                return NotFound();
            }

            _context.Objets.Remove(objet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjetExists(int id)
        {
            return _context.Objets.Any(e => e.IdObjet == id);
        }
    }
}
