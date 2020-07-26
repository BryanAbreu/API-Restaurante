using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Plato
    {
        public int Id { get; set; }
        public string NombrePlato { get; set; }
        public int Precio { get; set; }
        public int CantidadPersonas { get; set; }
        public string Ingredientes { get; set; }
        public string Categoria { get; set; }
    }
}
