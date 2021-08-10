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
    public sealed class CoinsRepository : ICoinsRepository
    {
        private readonly string _connectionString;

        public CoinsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("VipClassDataServer");
        }

        public async Task<IEnumerable<Coins>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryAsync<Coins>("SELECT IdCoin, Name, Description, Active FROM Coins");

            return data;
        }

        public async Task<int> Add(AddCoinsSignature entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Coins (Name, Description, Active) " +
                        "VALUES (@Name, @Description, @Active)";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }

        public async Task<int> Add(Coins entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Coins (Name, Description, Active) " +
                        "VALUES (@Name, @Description, @Active)";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }

        public async Task<Coins> Get(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryFirstOrDefaultAsync<Coins>("SELECT IdCoin, Name, Description, Active FROM Coins " +
                                                                        "WHERE IdCoin = @Id", new { Id = id });

            return data;
        }

        public async Task<int> Update(Coins entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "UPDATE Coins " +
                        "SET Name = @Name, " +
                        "Description = @Description, " +
                        "Active = @Active " +
                        "WHERE IdCoin = @Id";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }

        public async Task<int> Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE Coins " +
                        "WHERE IdCoin = @Id";

            var result = await connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
    }
}