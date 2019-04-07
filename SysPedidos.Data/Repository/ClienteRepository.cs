using Dapper;
using Microsoft.Extensions.Configuration;
using SysPedidos.Model;
using SysPedidos.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SysPedidos.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public String GetConnection()
        {
            string connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            return connection;
        }

        public int AdicionarCliente(Cliente cliente)
        {
            string connection = GetConnection();

            var count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO Clientes(Nome, Telefone, Endereco, DataCriacao) " +
                                    "values(@NomeCliente, @Telfone, @Endereco, @DataCriacao)";

                    count = con.Execute(query, cliente);
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

        public Cliente DetalhesCliente(long id)
        {
            string connection = GetConnection();

            Cliente cliente = new Cliente();

            using (var conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();

                    var query = "SELECT * FROM Clientes where ClienteId = " + id;

                    cliente = conn.Query<Cliente>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

                return cliente;
            }
        }

        public List<Cliente> ListarClientes()
        {
            string connection = GetConnection();

            List<Cliente> ListaCliente = new List<Cliente>();

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    var query = "SELECT * FROM Clientes";

                    ListaCliente = con.Query<Cliente>(query).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return ListaCliente;
            }
        }

        public int DeletarCliente(long id)
        {
            string connection = GetConnection();

            int count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "DELETE FROM Clientes where ClienteId = " + id;

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

        public int EditarCliente(Cliente cliente)
        {
            var connection = GetConnection();

            int count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    var query = "UPDATE Clientes set NomeCliente = @NomeCliente, Telefone = @Telefone, " +
                                "Endereco = @Endereco, DataCriacao = @DataCriacao";

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
    }
}
