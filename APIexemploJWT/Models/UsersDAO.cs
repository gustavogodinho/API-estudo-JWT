using APIexemploJWT.Models;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace APIexemploJWT.Data
{
    public class UsersDAO
    {
        private IConfiguration _configuration;

        public UsersDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Find(string userID)
        {
            using (SqlConnection conexao = new SqlConnection(
                _configuration.GetConnectionString("ExemploJWT")))
            {
                return conexao.QueryFirstOrDefault<User>(
                    "SELECT UserID, AccessKey " +
                    "FROM dbo.UsersJWT " +
                    "WHERE UserID = @UserID", new { UserID = userID });
            }
        }
    }
}
