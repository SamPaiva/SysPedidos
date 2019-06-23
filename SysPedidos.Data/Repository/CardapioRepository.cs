using Dapper;
using Microsoft.Extensions.Configuration;
using SysPedidos.Model;
using SysPedidos.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SysPedidos.Data.Repository
{
    public class CardapioRepository : ICardapioRepository
    {
        private readonly IConfiguration _configuration;

        public CardapioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public String GetConnection()
        {
            string connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            return connection;
        }

        public int AddItemCardapio(Cardapio cardapio)
        {
            string connection = GetConnection();

            var count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO Cardapios values(@Item_cardapio, @Desc_Item";

                    count = con.Execute(query, cardapio);
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

        public Cliente CardapioDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<Cardapio> CardapioList()
        {
            string connection = GetConnection();

            List<Cardapio> ListaCardapio = new List<Cardapio>();

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    var query = "SELECT * FROM Cardapios";

                    ListaCardapio = con.Query<Cardapio>(query).AsList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return ListaCardapio;
            }
        }

        public int DeleteCardapio(long id)
        {
            string connection = GetConnection();

            int count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "DELETE FROM Cardapios where Cardapio_Id = " + id;

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
        public int EditCardapio(Cardapio cardapio)
        {
            var connection = GetConnection();

            int count = 0;

            using (var con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    var query = "UPDATE Cardapios set Item_Cardapio = @Item_Cardapio, Desc_Item = @Desc_Item";

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
