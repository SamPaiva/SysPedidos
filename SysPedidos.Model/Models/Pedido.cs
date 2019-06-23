using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysPedidos.Model
{
    public class Pedido
    {
        public long PedidoId { get; set; }

        public DateTime DataPedido { get; set; }

        public string Descricao { get; set; }

        public string NomeCliente { get; set; }
    }
}
