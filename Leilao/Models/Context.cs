using System.Data.Entity;

namespace Leilao.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbLeilao"){}

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Lance> Lances { get; set; }
        public DbSet<Leilao> Leilaos { get; set; }   
    }
}