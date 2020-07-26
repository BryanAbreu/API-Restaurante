using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using ViewModels;

namespace cena.Infrastructure.AutoMapper
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            ConfigureIngredientes();
            ConfigureMesa();
            ConfigureOrdenes();
            ConfigurePlato();
        }

        private void ConfigureIngredientes()
        {
            CreateMap<IngredietesViewModel, Ingredientes>().ReverseMap();
        }
        private void ConfigureMesa()
        {
            CreateMap<MesaViewModel, Mesas>().ReverseMap();
        
        }
        private void ConfigurePlato()
        {
            CreateMap<PlatoViewModel, Plato>().ReverseMap();
        }
        private void ConfigureOrdenes()
        {
            CreateMap<OrdenesViewModel, Ordenes>().ReverseMap();

        }
       
    }
}
