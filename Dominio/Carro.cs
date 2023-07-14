using System.Collections.Generic;

namespace Dominio
{
    public class Carro
    {
        public Carro(int carId)
        {
            idCarrito = carId;
            Cantidad = 1;
        }
        public Carro()
        {

        }
        public int idCarrito { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        public int precioCarrito { get; set; }
        public EstadoCarrito Estado { get; set; }
        public Usuario usuario { get; set; }
        public int Cantidad { get; set; }
    }

}
