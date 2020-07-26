using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class OrdenesViewModel
    {
        public int Id { get; set; }
        public string Mesa { get; set; }
        public string Platos { get; set; }
        public int Subtotal { get; set; }
        public string Estado { get; set; }
    }
}
