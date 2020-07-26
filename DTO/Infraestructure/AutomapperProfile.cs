using AutoMapper;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Infraestructure
{
     public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            ConfigureIngredientes();
            ConfigureMesa();
            ConfigureOrdenes();
            ConfigurePlato();
        
        }


        private void ConfigureIngredientes()
        {
            CreateMap<IngredientesDTO, Ingredientes>().ReverseMap();
        }
        private void ConfigureMesa()
        {
            CreateMap<MesaDTO, Mesas>().ReverseMap();

        }
        private void ConfigurePlato()
        {
            CreateMap<PlatoDTO, Plato>().ReverseMap();
        }
        private void ConfigureOrdenes()
        {
            CreateMap<OrdenesDTO, Ordenes>().ReverseMap();

        }

    }
}
