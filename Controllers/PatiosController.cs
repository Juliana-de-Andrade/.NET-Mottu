using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using challenger.Domain.Entities;
using challenger.Infrastructure.Context;
using challenger.Infrastructure.Persistence.Repositories;
using challenger.Infrastructure.DTO.Request;
using System.Net;

namespace challenger.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PatiosController : ControllerBase
    {
        private readonly IRepository<Patio> _patioRepository;
        private readonly IPatioRepository _ratioRepository;
            
        public PatiosController(IRepository<Patio> patioRepository, IPatioRepository ratioRepository)
        {
            _patioRepository = patioRepository;
            _ratioRepository = ratioRepository;
        }

        // GET: api/Patios
        [HttpGet]
        public async Task<IEnumerable<Patio>> GetPatios()
        {
            return await _patioRepository.GetAllAsync();
        }

        // GET: api/Patios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> GetPatio(Guid id)
        {
            var patio = await _patioRepository.GetByIdAssync(id);

            if (patio == null)
            {
                return NotFound();
            }

            return patio;
        }

        // GET: api/Patios/cidade/SaoPaulo
        [HttpGet("cidade/{cidade}")]
        public async Task<ActionResult<IEnumerable<Patio>>> GetPatiosPorCidade(string cidade)
        {
            var patios = await _ratioRepository.GetByCidadeAsync(cidade);

            if (!patios.Any())
            {
                return NotFound($"Nenhum pátio encontrado para a cidade '{cidade}'.");
            }

            return Ok(patios);
        }

        // PUT: api/Patios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatio(Guid id, PatioRequest patioRequest)
        {
            var patioExistente = await _patioRepository.GetByIdAssync(id);

            if (patioExistente == null)
                return NotFound("Pátio não encontrado.");



            if (id != patioRequest.Id)
            {
                return BadRequest();
            }

            patioExistente.Update(patioRequest);

            _patioRepository.Update(patioExistente);

            
            return NoContent();
        }

        // POST: api/Patios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Patio>> PostPatio(PatioRequest patioRequest)
        {
            var patio = new Patio(patioRequest);

            await _patioRepository.AddAsync(patio);

            return CreatedAtAction("GetPatio", new { id = patio.Id }, patio);
        }

        // DELETE: api/Patios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatio(Guid id)
        {
            var patio = await _patioRepository.GetByIdAssync(id);
            if (patio == null)
            {
                return NotFound();
            }

            _patioRepository.Delete(patio);

            return NoContent();
        }                    
            
    }
}
