using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repository.Repository;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientesController : ControllerBase
    {
        private readonly IngredientesRepository _repository;

        public IngredientesController(IngredientesRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Ingredientes>>> Get()
        {


            var list = await _repository.GetAll();

            if (list.Count == 0)
            {
                return NotFound();

            }

            return list;

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredientes>> Get(int id)
        {


            var ingredientes = await _repository.GetById(id);

            if (ingredientes == null)
            {
                return NotFound();

            }
            return ingredientes;

        }
        [HttpPost]
        public async Task<IActionResult> Post(Ingredientes ingredientes)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(ingredientes);
                return NoContent();

            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id ,Ingredientes ingrediente)
        {
            if (ModelState.IsValid)
            {

               var responde= await _repository.UpdateIngrediente(id, ingrediente);

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
            var ingrediente = await _repository.GetById(id);
            if (ingrediente == null)
            {
                return NotFound();
            
            }
            await _repository.Delete(id);

            return NoContent();
        }
    }
}