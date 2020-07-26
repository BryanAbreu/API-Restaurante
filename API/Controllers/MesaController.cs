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
    public class MesaController : ControllerBase
    {
        private readonly MesaRepository _repository;

        public MesaController(MesaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Mesas>>> Get()
        {


            var list = await _repository.GetAll();

            if (list.Count == 0)
            {
                return NotFound();

            }

            return list;

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Mesas>> Get(int id)
        {


            var mesas = await _repository.GetById(id);

            if (mesas == null)
            {
                return NotFound();

            }
            return mesas;

        }
        [HttpPost]
        public async Task<IActionResult> Post(Mesas mesas)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(mesas);
                return NoContent();

            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Mesas mesas)
        {
            if (ModelState.IsValid)
            {

                var responde = await _repository.Updatemesa(id, mesas);

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
            var mesas = await _repository.GetById(id);
            if (mesas == null)
            {
                return NotFound();

            }
            await _repository.Delete(id);

            return NoContent();
        }
    }
}