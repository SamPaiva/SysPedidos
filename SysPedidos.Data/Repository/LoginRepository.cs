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
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _configuration;

        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public String GetConnection()
        {
            string connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            return connection;
        }

        public bool SignIn(Login User)
        {
            string connection = this.GetConnection();

            try
            {
                using (var con = new SqlConnection(connection))
                {
                    Login login = new Login();

                    con.Open();

                    var query = "SELECT * FROM LOGINS WHERE LOGINS.USUARIO = @USUARIO AND LOGINS.SENHA = @SENHA";


                    login = con.Query<Login>(query, new {Usuario = new DbString { Value = User.Usuario}, Senha = new DbString { Value = User.Senha} }).FirstOrDefault();

                    if (login != null)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
