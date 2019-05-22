using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminPacientes.Models;

namespace AdminPacientes.Controllers
{
    [Produces("application/json")]
    [Route("api/Tutores")]
    [ApiController]
    public class TutoresController : ControllerBase
    {
        private readonly AdminContexto _context;

        public TutoresController(AdminContexto context)
        {
            _context = context;
        }

        // GET: api/Tutores
        [HttpGet]
        public IEnumerable<Tutor> GetTutores()
        {
            return _context.Tutores;
        }

        // GET: api/Tutores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/Tutores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor([FromRoute] int id, [FromBody] Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.Id)
            {
                return BadRequest();
            }

            _context.Entry(tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
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

        // POST: api/Tutores
        [HttpPost]
        public async Task<IActionResult> PostTutor([FromBody] Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutor", new { id = tutor.Id }, tutor);
        }

        // DELETE: api/Tutores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();

            return Ok(tutor);
        }

        private bool TutorExists(int id)
        {
            return _context.Tutores.Any(e => e.Id == id);
        }
    }
}