using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class PlatoIngredienteRepository : RepositoryBase<PlatoIngredientes, CenaContext>
    {
       
        private readonly PlatoRepository _platoRepository;
        private readonly IngredientesRepository _ingredientesRepository;

        public PlatoIngredienteRepository(CenaContext context) : base(context)
        {

            _platoRepository = new PlatoRepository(context);
            _ingredientesRepository = new IngredientesRepository(context);

        }
        //public async Task<List<PlatoIngredienteRepository>> GetIngredientesDTOByIds(List<int> id)
        //{
        //    var list = await GetAll();
        //    list = await list.AsQueryable().Where(x => id.Contains(x.IdIngrediente)).ToListAsync();

        //    var ListDTO = new List<PlatoIngredientes>();

        //    list.ForEach(x =>
        //    {
        //        var dto = new PlatoIngredientes
        //        {
        //            IdIngrediente = x.IdIngrediente,
        //            IdPlatos = x.IdPlatos


        //        };
        //        ListDTO.Add(dto);
        //    });
        //    return (ListDTO;
        //}
        public async Task<bool> addplatoIngrediente(List<int> IngredienteIds, int platoid)
        {
            foreach (var IngredienteId in IngredienteIds)
            {
                var platoIngrediente = new PlatoIngredientes
                {
                    IdPlatos = platoid,
                    IdIngrediente = IngredienteId

                };
               await base.Add(platoIngrediente);
            }
            return true;

        }

    }
}
