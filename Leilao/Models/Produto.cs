using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Models
{
    [Table("Produto")]
    public class Produto
    {
        public Produto()
        {

        }

        public Produto(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; private set; }

        public decimal Valor { get; private set; }
    }
}