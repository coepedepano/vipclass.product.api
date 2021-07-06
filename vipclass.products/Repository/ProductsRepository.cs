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

        public Task<Products> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Products entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
