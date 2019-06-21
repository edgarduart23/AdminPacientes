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
    [Route("api/[controller]")]
    [ApiController]
    public class DomiciliosController : ControllerBase
    {
        private readonly AdminContexto _context;

        public DomiciliosController(AdminContexto context)
        {
            _context = context;
        }

        // GET: api/Domicilios
        [HttpGet]
        public IEnumerable<Domicilio> GetDomicilios()
        {
            return _context.Domicilios;
        }

        // GET: api/Domicilios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDomicilio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domicilio = await _context.Domicilios.FindAsync(id);

            if (domicilio == null)
            {
                return NotFound();
            }

            return Ok(domicilio);
        }

        // PUT: api/Domicilios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomicilio([FromRoute] int id, [FromBody] Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != domicilio.Id)
            {
                return BadRequest();
            }

            _context.Entry(domicilio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomicilioExists(id))
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

        // POST: api/Domicilios
        [HttpPost]
        public async Task<IActionResult> PostDomicilio([FromBody] Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Domicilios.Add(domicilio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDomicilio", new { id = domicilio.Id }, domicilio);
        }

        // DELETE: api/Domicilios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomicilio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domicilio = await _context.Domicilios.FindAsync(id);
            if (domicilio == null)
            {
                return NotFound();
            }

            _context.Domicilios.Remove(domicilio);
            await _context.SaveChangesAsync();

            return Ok(domicilio);
        }

        private bool DomicilioExists(int id)
        {
            return _context.Domicilios.Any(e => e.Id == id);
        }
    }
}