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

        public void AddArticle(Carro art)
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

        public void deleteArticle(Carro art)
        {
            Carro existingArticle = ArtList.Find(a => a.idCarrito== art.idCarrito);
            if (existingArticle != null && existingArticle.Cantidad > 1)
            {
                existingArticle.Cantidad--;
            }
            else if (existingArticle != null && existingArticle.Cantidad == 1)
            {
                RemoveArticle(art);
            }
        }


        public void RemoveArticle(Carro art)
        {
            Carro current = GetArticle(art.idCarrito);
            ArtList.Remove(current);
        }

        public Carro GetArticle(int id)
        {
            return ArtList.Find(a => a.idCarrito == id);
        }

        public bool HasArticleId(int id)
        {
            return ArtList.Contains(GetArticle(id));
        }

        public List<Carro> GetArticles()
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
            return GetArticle(id).Cantidad;
        }
    }
}

