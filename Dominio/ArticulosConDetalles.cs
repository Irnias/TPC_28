using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticulosConDetalles:Articulo
    {
        public int Cantidad { get; set; }
        public decimal PrecioViejo { get; set; }
    }
}
