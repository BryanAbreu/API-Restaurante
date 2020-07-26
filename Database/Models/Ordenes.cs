using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Ordenes
    {
        public int Id { get; set; }
        public string Mesa { get; set; }
        public string Platos { get; set; }
        public int Subtotal { get; set; }
        public string Estado { get; set; }
    }
}
