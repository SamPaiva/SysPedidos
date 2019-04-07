using System;

namespace SysPedidos.Model
{
    public class Pedido
    {
        public long PedidoId { get; set; }

        public DateTime DataPedido { get; set; }

        public virtual Cardapio Cardapio { get; set; }
    }
}
