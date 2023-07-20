using System.Collections.Generic;

namespace Dominio
{
    public class CarroConArticulos
    {
        List<ArtDentroDelCarrito> ArtList = new List<ArtDentroDelCarrito>();

        public void agregarArticulo(ArtDentroDelCarrito art)
        {
            ArtDentroDelCarrito existingArticle = ArtList.Find(a => a.idCarrito == art.idCarrito);
            if (existingArticle != null)
            {
                existingArticle.Cantidad++;
            }
            else
            {
                ArtList.Add(art);
            }
        }

        public void eliminarArticulo(ArtDentroDelCarrito art)
        {
            ArtDentroDelCarrito existingArticle = ArtList.Find(a => a.idCarrito == art.idCarrito);
            if (existingArticle != null && existingArticle.Cantidad > 1)
            {
                existingArticle.Cantidad--;
            }
            else if (existingArticle != null && existingArticle.Cantidad == 1)
            {
                removerArticulo(art);
            }
        }


        public void removerArticulo(ArtDentroDelCarrito art)
        {
            ArtDentroDelCarrito current = obtenerArticulo(art.idCarrito);
            ArtList.Remove(current);
        }

        public ArtDentroDelCarrito obtenerArticulo(int id)
        {
            return ArtList.Find(a => a.idCarrito == id);
        }

        public bool tieneIdArticulo(int id)
        {
            return ArtList.Contains(obtenerArticulo(id));
        }

        public List<ArtDentroDelCarrito> obtenerListaArticulos()
        {
            return ArtList;
        }

        public int GetTotalItems()
        {
            int total = 0;
            foreach (var article in ArtList)
            {
                total += article.Cantidad;
            }
            return total;
        }

        public int GetArticleQuantity(int id)
        {
            return obtenerArticulo(id).Cantidad;
        }

        public void limpiarCarrito()
        {
            ArtList.Clear(); // Vaciar la lista de artículos del carrito
        }
    }
}

