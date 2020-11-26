using Leilao.Models;
using System;
using System.Linq;

namespace Leilao.DAO
{
    public class PessoaRepository
    {
        public static bool CreatePessoa(Pessoa pessoa)
        {
            using (Context ctx = new Context())
            {
                try
                {
                    if (BuscarUsuarioPorEmail(ctx, pessoa.Email) == null)
                    {
                        ctx.Pessoas.Add(pessoa);
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static Pessoa BuscarUsuarioPorEmail(Context ctx, string email)
        {
            return ctx.Pessoas.FirstOrDefault(u => u.Email.Equals(email));
        }

        public static Pessoa BuscarUsuarioPorEmail(string email)
        {
            using (Context ctx = new Context())
            {
                return ctx.Pessoas.FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public static Pessoa BuscarUsuarioPorLoginSenha(Pessoa pessoa)
        {
            using (Context ctx = new Context())
            {
                return ctx.Pessoas.FirstOrDefault(x => x.Senha == pessoa.Senha && x.Email == pessoa.Email);
            }
        }

        public static Pessoa BuscarUsuarioPorId(string id)
        {
            using (Context ctx = new Context())
            {
                return ctx.Pessoas.FirstOrDefault(x => x.Id.ToString() == id);
            }
        }
    }
}