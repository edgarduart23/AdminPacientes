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
    [Route("api/ObraSociales")]
    [ApiController]
    public class ObraSocialesController : ControllerBase
    {
        private readonly IObraSocialRepository _obraSocial;

        public ObraSocialesController(IObraSocialRepository obraSocial)
        {
            _obraSocial = obraSocial;
        }

        // GET: api/ObraSociales
        [HttpGet]
        public async Task<IEnumerable<ObraSocial>> GetObraSociales()
        {
            return await _obraSocial.GetAll();
        }

        // GET: api/ObraSociales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObraSocial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obraSocial = await _obraSocial.GetById(id);

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

            await _obraSocial.Update(obraSocial);

            try
            {
                await _obraSocial.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_obraSocial.exists(id))
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

            await _obraSocial.Add(obraSocial);
            await _obraSocial.SaveChanges();

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

            var obraSocial = await _obraSocial.GetById(id);
            if (obraSocial == null)
            {
                return NotFound();
            }

            await _obraSocial.Remove(obraSocial);
            await _obraSocial.SaveChanges();

            return Ok(obraSocial);
        }

       
    }
}