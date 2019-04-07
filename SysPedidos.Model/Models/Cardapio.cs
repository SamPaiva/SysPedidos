using System;
using System.Collections.Generic;
using System.Text;

namespace SysPedidos.Model
{
    public class Cardapio
    {
        public long CardapioId { get; set; }

        public List<string> ItensCardapio { get; set; }

        public string DescItem { get; set; }
    }
}
