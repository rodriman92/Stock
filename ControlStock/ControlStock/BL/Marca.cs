using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStock.BL
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string DescripcionMarca { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
