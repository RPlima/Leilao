using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leilao.DAO
{
    public class ProdutoRepository
    {
        public static bool CreateProduto(Produto produto)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    ctx.Produtos.Add(produto);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Produto> ListAllProduto()
        {
            using (Context ctx = new Context())
            {
                return ctx.Produtos.ToList();
            }
        }

        public static Produto GetProdutoById(int id)
        {
            using (Context ctx = new Context())
            {
                return ctx.Produtos.Where(p => p.Id == id).FirstOrDefault();
            }
        }
    }
}