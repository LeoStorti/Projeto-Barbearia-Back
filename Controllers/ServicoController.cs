﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIBarbearia.Models;
using API.Context;

namespace APIBarbearia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ServicosController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Servicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servico>>> GetServicos()
        {
            return await _context.Servicos.ToListAsync();
        }

        // GET: api/Servicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetServico(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }

        // PUT: api/Servicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, Servico servico)
        {
            if (id != servico.ServicoId)
            {
                return BadRequest();
            }

            _context.Entry(servico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicoExists(id))
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

        // POST: api/Servicos
        [HttpPost]
        public async Task<ActionResult<Servico>> PostServico(Servico servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServico", new { id = servico.ServicoId }, servico);
        }

        // DELETE: api/Servicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicoExists(int id)
        {
            return _context.Servicos.Any(e => e.ServicoId == id);
        }
    }
}
