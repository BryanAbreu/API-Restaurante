using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;
using DTO;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;

namespace Repository.Repository
{
    public class PlatoRepository : RepositoryBase<Plato, CenaContext>
    {
        private readonly CenaContext _Context;
        private readonly IMapper _mapper;

        public PlatoRepository(CenaContext context, IMapper mapper) : base(context)

        {
            _Context = context;
            _mapper = mapper;
           

        }

        public PlatoRepository(CenaContext context) : base(context)
        {
        }

        public async Task<List<PlatoDTO>> GetAllDTO()
        {
         
            var ListDTO = new List<PlatoDTO>();

            foreach( var item in ListDTO)
            {
                
                var dto = _mapper.Map<PlatoDTO>(item);

                return ListDTO;
        
            }
               return null; 

        }
        public async Task<bool> Anyplatos(int id)
        {
            var list = await GetAll();
            var isAny = list.AsQueryable().Any(x => x.Id == id);
            return isAny;
        }

        public async Task<bool> UpdatePlato(int id, Plato entity)
        {
            try
            {
                var plato = await GetById(id);
                plato.Ingredientes = entity.Ingredientes;
                await Update(plato);
                return true;
            }
            catch (Exception )
            {

                return false;
            }

        }
        public async Task<List<PlatoDTO>> GetIngredientesDTOByIds(List<int> ids)
        {
            var list = await GetAll();
            list = await list.AsQueryable().Where(x => ids.Contains(x.Id)).ToListAsync();

            var ListDTO = new List<PlatoDTO>();


            foreach (var item in list)
            {
                var dto = _mapper.Map<PlatoDTO>(item);

                ListDTO.Add(dto);
            };
            return ListDTO;
        }
    }
}