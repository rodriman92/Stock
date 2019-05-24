using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStock.BL
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public string CUIT { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Localidad { get; set; }

        public object Clone()
        {

            return this.MemberwiseClone();
        }
    }
}
