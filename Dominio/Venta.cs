using System;
using System.ComponentModel;

namespace Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public Carro ventaCarro { get; set; }
        public string TipoPago { get; set; } // "EFECTIVO" "TARJETA"
        public string TipoEntrega { get; set; } // "coordinar" "retira por local"

    }
}
