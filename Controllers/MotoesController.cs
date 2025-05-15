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

namespace challenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoesController : ControllerBase
    {
        private readonly IRepository<Moto> _motoesRepository;

        public MotoesController(IRepository<Moto> motoesRepository, IMotoRepository iMotoesRepository)
        {
            _motoesRepository = motoesRepository;
            _iMotoesRepository = iMotoesRepository;
        }

        private readonly IMotoRepository _iMotoesRepository;

        // GET: api/Motoes
        [HttpGet]
        public async Task<IEnumerable<Moto>> GetMotos()
        {
            return await _motoesRepository.GetAllAsync();
        }

        // GET: api/Motoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetMoto(Guid id)
        {
            var moto = await _motoesRepository.GetByIdAssync(id);

            if (moto == null)
            {
                return NotFound();
            }

            return moto;
        }

        // GET: api/Motoes/placa/{placa}
        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<Moto>> GetMotoPorPlaca(string placa)
        {
            var moto = await _iMotoesRepository.GetByPlacaAsync(placa);

            if (moto == null)
            {
                return NotFound($"Moto com placa '{placa}' não encontrada.");
            }

            return Ok(moto);
        }


        // PUT: api/Motoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoto(Guid id, Moto moto)
        {
            if (id != moto.Id)
            {
                return BadRequest();
            }

            _motoesRepository.Update(moto);
            

            return NoContent();
        }

        // POST: api/Motoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<Moto>> PostMoto(MotoRequest motoRequest)
        {
            var moto = new Moto(motoRequest);

            await _motoesRepository.AddAsync(moto);

            return CreatedAtAction("GetMoto", new { id = moto.Id }, moto);
        }

        // DELETE: api/Motoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto(Guid id)
        {
            var moto = await _motoesRepository.GetByIdAssync(id);
            if (moto == null)
            {
                return NotFound();
            }

            _motoesRepository.Delete(moto);

            return NoContent();
        }

    }
}
