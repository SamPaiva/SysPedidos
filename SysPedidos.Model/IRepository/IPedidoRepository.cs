using System.Collections.Generic;

namespace SysPedidos.Model.IRepository
{
    public interface IPedidoRepository
    {
        List<Pedido> ListarPedidos();

        int AdicionarPedido(Pedido pedido);

        Pedido DetalhesPedido(long id);

        int EditarPedido(Pedido pedido);

        int DeletarPedido(long id);
    }
}
