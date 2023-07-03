using System.Collections.Generic;

namespace Dominio
{
    internal class Carrito
    {
        public int Id { get; set; }
        public List<Articulo> ListaArticulos;
        public int precioCarrito { get; set; }
        public EstadoCarrito Estado { get; set; }
        public Usuario usuario { get; set; }

    }
}
