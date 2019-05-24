using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStock.BL
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public string CodigoCategoria { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
