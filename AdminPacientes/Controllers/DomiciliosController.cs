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
    [Route("api/Domicilios")]
    [ApiController]
    public class DomiciliosController : ControllerBase
    {
        private readonly IDomicilioRepository _context;

        public DomiciliosController(IDomicilioRepository context)
        {
            _context = context;
        }

        // GET: api/Domicilios
        [HttpGet]
        public async Task<IEnumerable<Domicilio>> GetDomicilios()
        {
            return await _context.GetAll();
        }

        // GET: api/Domicilios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDomicilio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var domicilio = await _context.GetById(id);

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

            await _context.Update(domicilio);

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

        // POST: api/Domicilios
        [HttpPost]
        public async Task<IActionResult> PostDomicilio([FromBody] Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Add(domicilio);
            await _context.SaveChanges();

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

            var domicilio = await _context.GetById(id);
            if (domicilio == null)
            {
                return NotFound();
            }

            await _context.Remove(domicilio);
            await _context.SaveChanges();

            return Ok(domicilio);
        }

        
    }
}