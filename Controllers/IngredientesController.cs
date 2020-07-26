using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using ViewModels;

namespace cena.Controllers
{
    public class IngredientesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IngredientesRepository _Repository;
        private readonly CenaContext _context;

        public IngredientesController(IMapper mapper, IngredientesRepository repository, CenaContext context)
        {

            _mapper = mapper;
            _Repository = repository;
            _context = context;

        }
        //Get Ingredientes 
        public async Task<IActionResult> Index()
        {
            var listEntity = await _Repository.GetAll();

            List<IngredietesViewModel> vms = new List<IngredietesViewModel>();

            listEntity.ForEach(item =>
            {
                var vm = _mapper.Map<IngredietesViewModel>(item);
                vms.Add(vm);

            });


            return View(vms);
        }
        //Get ingredientes /details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ingredientes = await _Repository.GetById(id.Value);

            if (ingredientes == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<IngredietesViewModel>(ingredientes);
            return View(vm);
        }


        //Post:Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredietesViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var entity = _mapper.Map<Ingredientes>(vm);
                await _Repository.Add(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);              
        
        }

        //Get Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Ingrediente = await _Repository.GetById(id.Value);
            if (Ingrediente == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<IngredietesViewModel>(Ingrediente);
            return View(vm);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IngredietesViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = new Ingredientes
                    {
                        Id = vm.Id,
                        NombreIngrediente = vm.NombreIngrediente
                    };
                    await _Repository.Update(entity);
                }
                catch(DbUpdateConcurrencyException)
                {
                    var isExists = await IngredientesExixst(vm.Id);
                    if (!isExists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                
                
                }
                
             return RedirectToAction(nameof(Index));
            }

            return View(vm);      
        }

        private async Task<bool> IngredientesExixst(int id)
        {
            return await _Repository.AnyIngrediente(id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ingrediente =await _Repository.GetById(id.Value);
            if (ingrediente == null)
            {
                return NotFound();
            }
            var vm = new IngredietesViewModel
            {
                Id = ingrediente.Id,
                NombreIngrediente = ingrediente.NombreIngrediente


            };
            return View(vm);
        }

        //post delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleteconfirm(int id)
        {
            await _Repository.Delete(id);
            return RedirectToAction(nameof(Index));
        
        }
    
    }
}