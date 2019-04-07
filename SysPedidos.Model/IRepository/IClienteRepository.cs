using System.Collections.Generic;

namespace SysPedidos.Model.IRepository
{
    public interface IClienteRepository
    {
        List<Cliente> ListarClientes();

        int AdicionarCliente(Cliente cliente);

        Cliente DetalhesCliente(long id);

        int EditarCliente(Cliente cliente);

        int DeletarCliente(long id);
    }
}
