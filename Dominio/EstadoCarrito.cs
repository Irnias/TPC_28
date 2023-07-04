using System;
using System.ComponentModel;

namespace Dominio
{
    public class EstadoCarrito
    {
        public int Id { get; set; }
        public string Estado { get; set;} // "Armando el carrito" "terminado sin pagar" "con venta asociada"
    }
}
