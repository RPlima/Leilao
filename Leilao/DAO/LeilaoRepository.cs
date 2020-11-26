using Leilao.DTO;
using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leilao.DAO
{
    public class LeilaoRepository
    {
        public static Models.Leilao CreateLeilao(Models.Leilao leilao)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    ctx.Leilaos.Attach(leilao);
                    ctx.Leilaos.Add(leilao);
                    ctx.SaveChanges();
                    return leilao;
                }
                catch (Exception ex)
                {
                    return leilao;
                }
            }
        }

        public static Models.Leilao GetLeilaoByProduct(Produto produto)
        {
            using (Context ctx = new Context())
            {
                return ctx.Leilaos.Include("Produto").Include("Lances").FirstOrDefault(u => u.Produto.Id == produto.Id);
            }
        }

        public static Models.Leilao BuscarLeilaoPorId(string id)
        {
            using (Context ctx = new Context())
            {
                return ctx.Leilaos.Include("Produto").Include("Lances").FirstOrDefault(x => x.Id.ToString() == id);
            }
        }

        public static void SaveLance(Lance lance)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    ctx.Lances.Attach(lance);
                    ctx.Lances.Add(lance);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public static List<LanceDTO> GetAll()
        {
            using (Context ctx = new Context())
            {
                List<Lance> lances = ctx.Lances
                        .Include("Produto")
                        .Include("Pessoa")
                        .Include("Leilao")
                    .ToList();
                List<LanceDTO> lancesDTO = new List<LanceDTO>();
                foreach (var itemLances in lances)
                {
                    lancesDTO.Add(new LanceDTO()
                    {
                        NomePessoa = itemLances.Pessoa.Nome,
                        NomeProduto = itemLances.Produto.Nome,
                        Valor = itemLances.Valor
                    });
                }
                return lancesDTO;
            }
        }
    }
}