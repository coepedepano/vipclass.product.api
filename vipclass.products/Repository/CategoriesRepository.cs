using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using vipclass.products.Domain.Models;
using vipclass.products.Domain.Models.Signature;
using vipclass.products.Repository.Interface;

namespace vipclass.products.Repository
{
    public sealed class CategoriesRepository : ICategoriesRepository
    {
        private readonly string _connectionString;

        public CategoriesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("VipClassDataServer");
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryAsync<Categories>("SELECT IdCategorie, Description, Active FROM Categories");

            return data;
        }

        public async Task<int> Add(AddCategoriesSignature entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Categories (Description, Active) " +
                        "VALUES (@Description, @Active)";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }

        public async Task<int> Add(Categories entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Categories (Description, Active) " +
                        "VALUES (@Description, @Active)";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }

        public async Task<Categories> Get(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryFirstOrDefaultAsync<Categories>("SELECT IdCategorie, Description, Active FROM Categories " +
                                                                    "WHERE IdCategorie = @Id", new { Id = id });

            return data;
        }

        public async Task<int> Update(Categories entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "UPDATE Categories " +
                        "SET Description = @Description, " +
                        "Active = @Active " +
                        "WHERE IdCategorie = @Id";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }

        public async Task<int> Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE Categories " +
                        "WHERE IdCategorie = @Id";

            var result = await connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
    }
}