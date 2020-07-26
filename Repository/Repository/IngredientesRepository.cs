using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class IngredientesRepository : RepositoryBase<Ingredientes, CenaContext>
    {
        private readonly IMapper _mapper;
        public readonly CenaContext _context;


        public IngredientesRepository(CenaContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IngredientesRepository(CenaContext context) : base(context)
        {
        }

        public async Task<bool> UpdateIngrediente(int id, Ingredientes entity)
        {
            try
            {
            var ingrediente = await GetById(id);
            ingrediente.NombreIngrediente = entity.NombreIngrediente;
            await Update(ingrediente);
            return true;
            }
            catch (Exception e)
            {

                return false;
            }
            
        }

        public async Task<bool> AnyIngrediente(int id)
        {
            var list = await  GetAll();
            var isAny =  list.AsQueryable().Any(x => x.Id == id);
            return isAny;
        }

        public async Task<List<IngredientesDTO>> GetIngredientesDTOByIds(List<int> ids)
        {
            var list = await GetAll();
            list = await list.AsQueryable().Where(x => ids.Contains(x.Id)).ToListAsync();

            var ListDTO = new List<IngredientesDTO>();
            
            foreach(var item in list)
            {
                var dto = _mapper.Map<IngredientesDTO>(item);
               
                ListDTO.Add(dto);
            };
            return ListDTO;
        }

    }
}
