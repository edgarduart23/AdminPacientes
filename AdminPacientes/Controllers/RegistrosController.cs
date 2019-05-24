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
    [Route("api/Registros")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly IRegistroRepository _context;

        public RegistrosController(IRegistroRepository context)
        {
            _context = context;
        }

        // GET: api/Registros
        [HttpGet]
        public async Task<IEnumerable<Registro>> GetRegistros()
        {
            return await _context.GetAll();
        }

        // GET: api/Registros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.GetById(id);

            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }

        // PUT: api/Registros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro([FromRoute] int id, [FromBody] Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro.Id)
            {
                return BadRequest();
            }

            await _context.Update(registro);

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

        // POST: api/Registros
        [HttpPost]
        public async Task<IActionResult> PostRegistro([FromBody] Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Add(registro);
            await _context.SaveChanges();

            return CreatedAtAction("GetRegistro", new { id = registro.Id }, registro);
        }

        // DELETE: api/Registros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.GetById(id);
            if (registro == null)
            {
                return NotFound();
            }

            await _context.Remove(registro);
            await _context.SaveChanges();

            return Ok(registro);
        }

        
    }
}