using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using DTO;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatoController : ControllerBase
    {
        private readonly PlatoRepository _repository;
       

        public PlatoController(PlatoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Plato>>> Get()
        {


            var list = await _repository.GetAll();

            if (list.Count == 0)
            {
                return NotFound();

            }

            return list;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plato>> Get(int id)
        {


            var Plato = await _repository.GetById(id);

            if (Plato == null)
            {
                return NotFound();

            }
            return Plato;

        }
        [HttpPost]
        public async Task<IActionResult> Post(Plato plato)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(plato);
                return NoContent();

            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Plato plato)
        {
            if (ModelState.IsValid)
            {

                var responde = await _repository.UpdatePlato(id,plato);

                if (responde)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(500);
                }


            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Plato = await _repository.GetById(id);
            if (Plato == null)
            {
                return NotFound();

            }
            await _repository.Delete(id);

            return NoContent();
        }

    }
}