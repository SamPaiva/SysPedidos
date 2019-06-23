using Dapper;
using Microsoft.Extensions.Configuration;
using SysPedidos.Model;
using SysPedidos.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SysPedidos.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IConfiguration _configuration;

        public PedidoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public String GetConnection()
        {
            string connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            return connection;
        }

        public int AdicionarPedido(Pedido pedido)
        {
            string connection = GetConnection();

            var count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO Pedidos(DataPedido, Cardapio, Cliente) " +
                                    "values(@DataPedido, @Cardapio, @Cliente)";

                    count = con.Execute(query, pedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;

            }
        }

        public int DeletarPedido(long id)
        {
            string connection = GetConnection();

            int count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "DELETE FROM Pedidos where Pedido_Id = " + id;

                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }

        }

        public Pedido DetalhesPedido(long id)
        {
            string connection = GetConnection();

            Pedido pedido = new Pedido();

            using (var conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();

                    var query = "SELECT * FROM Pedidos where Pedido_Id = " + id;

                    pedido = conn.Query<Pedido>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

                return pedido;
            }
        }

        public int EditarPedido(Pedido pedido)
        {
            var connection = GetConnection();

            int count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    var query = "UPDATE Pedidos set Cardapio.Item_Cardapio = @Cardapio.Item_Cardapio";

                    count = con.Execute(query);

                    return count;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public List<Pedido> ListarPedidos()
        {
            string connection = GetConnection();

            List<Pedido> ListaPedido = new List<Pedido>();

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    var query = @"SELECT PED.PEDIDO_ID PedidoId, PED.DATA_PEDIDO DataPedido, CLI.NOME_CLIENTE NomeCliente, PED.DESCRICAO_PEDIDO Descricao 
                                    FROM PEDIDOS AS PED WITH(NOLOCK)
		                                INNER JOIN CLIENTES AS CLI WITH(NOLOCK)
		                                ON CLI.CLIENTE_ID = PED.CLIENTE_ID";

                    ListaPedido = con.Query<Pedido>(query).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return ListaPedido;
            }
        }
    }
}
