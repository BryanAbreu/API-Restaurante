using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Repository;
using ViewModels;

namespace cena.Controllers
{
    public class PlatoController : Controller
    {
        private readonly IngredientesRepository _repositoryIngredientes;
        private readonly PlatoRepository _repository;
        private readonly IMapper _mapper;
        private readonly PlatoIngredienteRepository _platoIngredienteRepository;

        public PlatoController(PlatoRepository repository, IMapper mapper, IngredientesRepository repositoryIngredientes, PlatoIngredienteRepository platoIngredienteRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryIngredientes = repositoryIngredientes;
            _platoIngredienteRepository = platoIngredienteRepository;
        }

        // GET: Plato
        public ActionResult Index()
        {
            return View();
        }

        // GET: Plato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Plato/Create
        public async Task<ActionResult> Create()
        {
            var ingredientesentity = await _repository.GetAll();
            List<IngredietesViewModel> listIngredientesVm = new List<IngredietesViewModel>();
            ingredientesentity.ForEach(item =>
            {
                var vm = _mapper.Map<IngredietesViewModel>(item);
                listIngredientesVm.Add(vm);

            });

            ViewBag.Ingredientes = listIngredientesVm;


            return View();
        }

        // POST: Plato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlatoViewModel vm,PlatoIngredientes vms)
        {
            if (ModelState.IsValid)
            {
                var platoEntity = _mapper.Map<Plato>(vm);
                await _repository.Add(platoEntity);
             

                return RedirectToAction("Index");

            }
           
        
       
                return View();
            
        }

        // GET: Plato/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plato = await _repository.GetById(id.Value);
            if (plato == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<PlatoViewModel>(plato);
            var IngredientesEntity = await _repositoryIngredientes.GetAll();

            List<IngredietesViewModel> listingredietesViewModelsvm = new List<IngredietesViewModel>();
            IngredientesEntity.ForEach(item => {

                var vmIngredientes = _mapper.Map<IngredietesViewModel>(item);
                listingredietesViewModelsvm.Add(vmIngredientes);
                      
            });


            ViewBag.Ingredientes = listingredietesViewModelsvm;
            

            return View();
        }

        // POST: Plato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PlatoViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }
            var plato = await _repository.GetById(vm.Id);
            if(plato==null)
            {
                return NotFound();

            }
            if (ModelState.IsValid)
            {
                plato.NombrePlato = vm.NombrePlato;
                plato.Ingredientes = vm.Ingredientes;
                plato.Precio = vm.Precio;
                plato.CantidadPersonas = vm.CantidadPersonas;
                plato.Categoria = vm.Categoria;

               await _repository.Update(plato);
            }

            return View(vm);
        }

        


        // GET: Plato/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if(id== null)
            {
                return NotFound();

            }

            var plato = await _repository.GetById(id.Value);

            if (plato == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<PlatoViewModel>(plato);

            return View();
        }

        // POST: Plato/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //post delete
        [HttpPost]

        public async Task<IActionResult> Deleteconfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             await _repository.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}