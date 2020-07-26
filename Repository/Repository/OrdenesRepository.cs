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
    public class OrdenesRepository : RepositoryBase<Ordenes, CenaContext>
    {
        public readonly CenaContext _context;
        private readonly IMapper _mapper;

        public OrdenesRepository(CenaContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<bool> UpdateOrden(int id, Ordenes entity)
        {
            try
            {
                var ordenes = await GetById(id);
                ordenes.Platos = entity.Platos;
            
                await Update(ordenes);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<bool> AnyOrdenes(int id)
        {
            var list = await GetAll();
            var isAny = list.AsQueryable().Any(x => x.Id == id);
            return isAny;
        }

        public async Task<List<OrdenesDTO>> GetOrdenesDTOByIds(List<int> ids)
        {
            var list = await GetAll();
            list = await list.AsQueryable().Where(x => ids.Contains(x.Id)).ToListAsync();

            var ListDTO = new List<OrdenesDTO>();

            foreach (var item in list)
            {
                var dto = _mapper.Map<OrdenesDTO>(item);

                ListDTO.Add(dto);
            };
            return ListDTO;
           
        }

    }
}