using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Mesas
    {
        public int Id { get; set; }
        public int CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
