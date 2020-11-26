using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Models
{
    [Table("Lance")]
    public class Lance
    {
        public Lance()
        {

        }

        public Lance(Pessoa pessoa, decimal valor, Produto produto, Leilao leilao)
        {
            Pessoa = pessoa;
            Valor = valor;
            Produto = produto;
            Leilao = leilao;
        }

        [Key]
        public int Id { get; set; }
        public virtual Pessoa Pessoa { get;  set; }

        public decimal Valor { get; private set; }

        public virtual Produto Produto { get;  set; }

        public virtual Leilao Leilao { get; set; }
    }
}