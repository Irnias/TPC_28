using System.Collections.Generic;

namespace Dominio
{
    public class ArtDentroDelCarrito
    {
        public ArtDentroDelCarrito(int carId)
        {
            idCarrito = carId;
            Cantidad = 1;
        }
        public ArtDentroDelCarrito()
        {

        }
        public int idCarrito { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        public int precioCarrito { get; set; }
        public EstadoCarrito Estado { get; set; }
        public Usuario usuario { get; set; }
        public int Cantidad { get; set; }
        public Envio EnvioActual { get; set; }

    }

}
