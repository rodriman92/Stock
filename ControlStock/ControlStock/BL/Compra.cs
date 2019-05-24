﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStock.BL
{
    public  class Compra
    {
        public int IdCompra { get; set; }
        public string Producto { get; set; }
        public Proveedor idProveedor { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
