using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using vipclass.products.Domain.Models;
using vipclass.products.Repository.Interface;

namespace vipclass.products.Repository
{
    public sealed class ProductsRepository : IProductsRepository
    {
        private readonly string _connectionString;

        public ProductsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("VipClassDataServer");
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryAsync<Products>("SELECT * FROM Products");

            return data;
        }

        public async Task<int> Add(Products parameters)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Products (IdCategories, Title, Description, Royalts, PutOnMarketPlace, Active) " +
                        "VALUES (@IdCategories, @Title, @Description, @Royalts, @PutOnMarketPlace, @Active)";

            var result = await connection.ExecuteAsync(query, parameters);

            return result;
        }

        public async Task<Products> Get(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryFirstAsync<Products>("SELECT Title, Description, Royalts, PutOnMarketPlace, Active " +
                                                                    "FROM Products " +
                                                                    "WHERE Id = @Id", id);

            return data;
        }

        public async Task<int> Update(Products entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "UPDATE Products " +
                        "SET Title = @Title, " +
                        "Description = @Description " +
                        "Royalts = @Royalts " +
                        "PutOnMarketPlace = @PutOnMarketPlace " +
                        "WHERE Id = @Id";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }

        public async Task<int> Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE Products " +
                        "WHERE Id = @Id";

            var result = await connection.ExecuteAsync(query, id);

            return result;
        }
    }
}
