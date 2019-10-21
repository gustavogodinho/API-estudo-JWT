using APIexemploJWT.Models;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace APIexemploJWT.Data
{
    public class UsersDAO
    {
        private IConfiguration _configuration;

        public UsersDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> Find(string userID)
        {
            using (SqlConnection conexao = new SqlConnection(_configuration.GetConnectionString("ExemploJWT")))
            {

                return await conexao.QueryFirstOrDefaultAsync<User>(
                    "SELECT UserID, AccessKey " +
                    "FROM dbo.UsersJWT " +
                    "WHERE UserID = @UserID", new { UserID = userID });
            }
        }
    }
}
