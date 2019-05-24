using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminPacientes.Models;
using AdminPacientes.Data.Interfaces;

namespace AdminPacientes.Controllers
{
    [Produces("application/json")]
    [Route("api/Tutores")]
    [ApiController]
    public class TutoresController : ControllerBase
    {
        private readonly ITutorRepository _context;

        public TutoresController(ITutorRepository context)
        {
            _context = context;
        }

        // GET: api/Tutores
        [HttpGet]
        public async Task<IEnumerable<Tutor>> GetTutores()
        {
            return await _context.GetAll();
        }

        // GET: api/Tutores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tutor = await _context.GetById(id);

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

            await _context.Update(tutor);

            try
            {
                await _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Exists(id))
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

            await _context.Add(tutor);
            await _context.SaveChanges();

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

            var tutor = await _context.GetById(id);
            if (tutor == null)
            {
                return NotFound();
            }

            await _context.Remove(tutor);
            await _context.SaveChanges();

            return Ok(tutor);
        }

        
    }
}