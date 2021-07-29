using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using vipclass.products.Domain.Models;
using vipclass.products.Domain.Models.Signature;
using vipclass.products.Repository.Interface;
using static Dapper.SqlMapper;

namespace vipclass.products.Repository
{
    public sealed class ProducerRepository : IProducerRepository
    {
        private readonly string _connectionString;

        public ProducerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("VipClassDataServer");
        }

        public async Task<IEnumerable<Producer>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryAsync<Producer>("SELECT * FROM Producer");

            return data;
        }

        public async Task<int> Add(Producer entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Producer (IdProduct, Wallet, Royalts, Active) " +
                        "VALUES (@IdProduct, @Wallet, @Royalts, @Active)";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }
        public async Task<Producer> Get(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryFirstOrDefaultAsync<Producer>("SELECT Title, Description, Royalts, PutOnMarketPlace, Active " +
                                                                            "FROM Producer " +
                                                                            "WHERE Id = @Id", new { Id = id });

            return data;
        }

        public async Task<int> Update(Producer entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "UPDATE Producer " +
                        "SET Title = @Title, " +
                        "Description = @Description, " +
                        "Royalts = @Royalts, " +
                        "PutOnMarketPlace = @PutOnMarketPlace " +
                        "WHERE Id = @Id";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }

        public async Task<int> Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE FROM Producer " +
                        "WHERE Id = @Id";

            var result = await connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
    }
}
