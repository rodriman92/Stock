using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStock.BL
{
    class ReciboVenta
    {
        public int IdRecibo { get; set; }
        public DateTime Fecha { get; set; }
        public string cliente { get; set; }
        public string producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioU { get; set; }
        public decimal Importe { get; set; }
        public decimal Entrada { get; set; }
        public decimal Salida { get; set; }
    }
}
