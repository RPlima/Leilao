using System.ComponentModel.DataAnnotations;

namespace Leilao.DTO
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get;  set; }
        public int Idade { get;  set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get;  set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public void CreatePerson(string nome, int idade, string email, string senha)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
            Senha = senha;
        }
    }
}