using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DTO
{
    public class MesaDTO
    {
        public int Id { get; set; }
        public int CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
