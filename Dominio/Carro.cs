using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carro
    {
        public Carro(int carId)
        {
            idCarrito = carId;
            Cantidad = 1;
        }

        public int idCarrito { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        public int precioCarrito { get; set; }
        public EstadoCarrito Estado { get; set; }
        public Usuario usuario { get; set; }
        public int Cantidad { get; set; }
    }

}
