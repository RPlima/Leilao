using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.DTO
{
    public class LanceDTO
    {
        public string NomePessoa { get; set; }

        public string NomeProduto { get; set; }

        public decimal Valor { get; set; }
    }
}