using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CarroConArticulos
    {
        List<Carro> ArtList = new List<Carro>();

        public void agregarArticulo(Carro art)
        {
            Carro existingArticle = ArtList.Find(a => a.idCarrito== art.idCarrito);
            if (existingArticle != null)
            {
                existingArticle.Cantidad++;
            }
            else
            {
                ArtList.Add(art);
            }
        }

        public void eliminarArticulo(Carro art)
        {
            Carro existingArticle = ArtList.Find(a => a.idCarrito== art.idCarrito);
            if (existingArticle != null && existingArticle.Cantidad > 1)
            {
                existingArticle.Cantidad--;
            }
            else if (existingArticle != null && existingArticle.Cantidad == 1)
            {
                removerArticulo(art);
            }
        }


        public void removerArticulo(Carro art)
        {
            Carro current = obtenerArticulo(art.idCarrito);
            ArtList.Remove(current);
        }

        public Carro obtenerArticulo(int id)
        {
            return ArtList.Find(a => a.idCarrito == id);
        }

        public bool tieneIdArticulo(int id)
        {
            return ArtList.Contains(obtenerArticulo(id));
        }

        public List<Carro> obtenerListaArticulos()
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
    }
}

