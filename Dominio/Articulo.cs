using System.Collections.Generic;

namespace Dominio
{
    public class Articulo
    {
        public int ArtId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionLarga { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public decimal Precio { get; set; }
    }
}
