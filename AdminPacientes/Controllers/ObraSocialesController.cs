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
    [Route("api/ObraSociales")]
    [ApiController]
    public class ObraSocialesController : ControllerBase
    {
        private readonly AdminContexto _context;

        public ObraSocialesController(AdminContexto context)
        {
            _context = context;
        }

        // GET: api/ObraSociales
        [HttpGet]
        public IEnumerable<ObraSocial> GetObraSociales()
        {
            return _context.ObraSociales;
        }

        // GET: api/ObraSociales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObraSocial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obraSocial = await _context.ObraSociales.FindAsync(id);

            if (obraSocial == null)
            {
                return NotFound();
            }

            return Ok(obraSocial);
        }

        // PUT: api/ObraSociales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObraSocial([FromRoute] int id, [FromBody] ObraSocial obraSocial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != obraSocial.Id)
            {
                return BadRequest();
            }

            _context.Entry(obraSocial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObraSocialExists(id))
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

        // POST: api/ObraSociales
        [HttpPost]
        public async Task<IActionResult> PostObraSocial([FromBody] ObraSocial obraSocial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ObraSociales.Add(obraSocial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObraSocial", new { id = obraSocial.Id }, obraSocial);
        }

        // DELETE: api/ObraSociales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObraSocial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obraSocial = await _context.ObraSociales.FindAsync(id);
            if (obraSocial == null)
            {
                return NotFound();
            }

            _context.ObraSociales.Remove(obraSocial);
            await _context.SaveChangesAsync();

            return Ok(obraSocial);
        }

        private bool ObraSocialExists(int id)
        {
            return _context.ObraSociales.Any(e => e.Id == id);
        }
    }
}