using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
   public class OrdenesDTO
    {
        public int Id { get; set; }
        public string Mesa { get; set; }
        public string Platos { get; set; }
        public int Subtotal { get; set; }
        public string Estado { get; set; }
    }
}
