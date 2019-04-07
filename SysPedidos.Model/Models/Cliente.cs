using System;

namespace SysPedidos.Model
{
    public class Cliente
    {
        public long ClienteId { get; set; }

        public string NomeCliente { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
