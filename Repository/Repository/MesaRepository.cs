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
    public class MesaRepository : RepositoryBase<Mesas, CenaContext>
    {
        public readonly CenaContext _context;
        private readonly IMapper _mapper;

        public MesaRepository(CenaContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<bool> Updatemesa(int id, Mesas entity)
        {
            try
            {
                var mesas = await GetById(id);
                mesas.Descripcion = entity.Descripcion;
                mesas.CantidadPersonas = entity.CantidadPersonas;
                await Update(mesas);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public async Task<bool> AnyMesa(int id)
        {
            var list = await GetAll();
            var isAny = list.AsQueryable().Any(x => x.Id == id);
            return isAny;
        }

        public async Task<List<MesaDTO>> GetMesaDTOByIds(List<int> ids)
        {
            var list = await GetAll();
            list = await list.AsQueryable().Where(x => ids.Contains(x.Id)).ToListAsync();

            var ListDTO = new List<MesaDTO>();

            foreach (var item in list)
            {
                var dto = _mapper.Map<MesaDTO>(item);

                ListDTO.Add(dto);
            };
            return ListDTO;
        }

    }
}