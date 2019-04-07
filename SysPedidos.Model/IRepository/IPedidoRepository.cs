using System.Collections.Generic;

namespace SysPedidos.Model.IRepository
{
    public interface IPedidoRepository
    {
        List<Pedido> PedidoList();

        int AddPedido(Pedido pedido);

        Pedido PedidoDetails(long id);

        int EditPedido(Pedido pedido);

        int DeletePedido(long id);
    }
}
