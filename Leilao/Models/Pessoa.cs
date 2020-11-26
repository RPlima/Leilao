using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leilao.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        public Pessoa()
        {
                
        }

        public Pessoa(string nome, int idade, string email, string senha)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
            Senha = senha;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

    }
}