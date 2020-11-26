using Leilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.DTO
{
    public class LeilaoDTO
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public List<Lance> Lances { get; set; }
    }
}