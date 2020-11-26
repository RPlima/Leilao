using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Leilao.Models
{
    [Table("Leilao")]
    public class Leilao
    {
        public Leilao()
        {

        }

        public Leilao(Produto produto)
        {
            Produto = produto;
        }

        [Key]
        public int Id { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual List<Lance> Lances { get; set; }

        public Lance MakeLance(Pessoa pessoa, decimal valor)
        {
            if (valor <= Produto.Valor)
                return null;

            if (Lances.Count == 0)
            {
                Lances = new List<Lance>();
                Lance lance = new Lance(pessoa, valor, Produto, this);
                Lances.Add(lance);
                return lance;
            }

            if (valor > Lances.Last().Valor)
            {
                Lance lance = new Lance(pessoa, valor, Produto, this);
                Lances.Add(lance);
                return lance;
            }
            else
                return null;

        }
    }
}