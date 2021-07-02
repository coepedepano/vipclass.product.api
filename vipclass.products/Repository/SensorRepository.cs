using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using vipclass.products.Domain;
using vipclass.products.Repository.Interface;

namespace vipclass.products.Repository
{
    public sealed class SensorRepository : ISensorRepository
    {
        private readonly string _connectionString;

        public SensorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("VipClassDataServer");
        }

        public IEnumerable<Sensor> ListAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var sensorData = connection.Query<Sensor>("SELECT * FROM Sensor");

            return sensorData;
        }

        public int Insert(long step)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Sensor (Step) VALUES (@step)";

            var result = connection.Execute(query, new { Step = step });

            return result;
        }
    }
}
