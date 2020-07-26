using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class PlatoIngredientes
    {
        public int IdPlatos { get; set; }
        public int IdIngrediente { get; set; }

        public virtual Ingredientes IdIngredienteNavigation { get; set; }
        public virtual Plato IdPlatosNavigation { get; set; }
    }
}
