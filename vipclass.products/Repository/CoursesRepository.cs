using System;
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
    public sealed class CoursesRepository : ICoursesRepository
    {
        private readonly string _connectionString;

        public CoursesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("VipClassDataServer");
        }

        public async Task<IEnumerable<Courses>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryAsync<Courses>("SELECT * FROM Courses");

            return data;
        }
        public async Task<int> Add(Courses entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Courses (IdCourse, Title, Description, Royalts, PutOnMarketPlace, Active) " +
                        "VALUES (@IdCourse, @Title, @Description, @Royalts, @PutOnMarketPlace, @Active)";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }
        public async Task<Courses> Get(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var data = await connection.QueryFirstOrDefaultAsync<Courses>("SELECT Title, Description, Royalts, PutOnMarketPlace, Active " +
                                                                    "FROM Courses " +
                                                                    "WHERE IdCourse = @Id", new { Id = id });

            return data;
        }
        public async Task<int> Update(Courses entity)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "UPDATE Courses " +
                        "SET Title = @Title, " +
                        "Description = @Description, " +
                        "Royalts = @Royalts, " +
                        "PutOnMarketPlace = @PutOnMarketPlace " +
                        "WHERE IdCourse = @Id";

            var result = await connection.ExecuteAsync(query, entity);

            return result;
        }
        public async Task<int> Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE FROM Courses " +
                        "WHERE IdCourse = @Id";

            var result = await connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
        public async Task Save(AddCourseSignature signature)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                var transaction = connection.BeginTransaction();
                var course = new DynamicParameters();
                course.Add("@IdCategorie", signature.IdCategorie);
                course.Add("@Title", signature.Title);
                course.Add("@Description", signature.Description);
                course.Add("@ImageCover", signature.ImageCover);
                course.Add("@Price", signature.Price);
                course.Add("@Active", signature.Active);

                await connection.ExecuteAsync("INSERT INTO Courses (IdCategorie, Title, Description, ImageCover, Price, Active) VALUES (@IdCategorie, @Title, @Description, @ImageCover, @Price, @Active)", course, transaction: transaction);
                var idCourse = Convert.ToInt64(connection.ExecuteScalar<object>("SELECT @@IDENTITY", null, transaction: transaction));

                var producer = new DynamicParameters();
                producer.Add("@IdCourse", idCourse);
                producer.Add("@Wallet", signature.Producer.Wallet);
                producer.Add("@Royalts", signature.Producer.Royalts);
                producer.Add("@Active", signature.Producer.Active);

                await connection.ExecuteAsync("INSERT INTO Producer (IdCourse, Wallet, Royalts, Active) VALUES (@IdCourse, @Wallet, @Royalts, @Active)", producer, transaction: transaction);

                foreach (var item in signature.CoProducer)
                {
                    var coProducer = new DynamicParameters();
                    coProducer.Add("@IdCourse", idCourse);
                    coProducer.Add("@Wallet", item.Wallet);
                    coProducer.Add("@Royalts", item.Royalts);
                    coProducer.Add("@Active", item.Active);

                    await connection.ExecuteAsync("INSERT INTO CoProducer (IdCourse, Wallet, Royalts, Active) VALUES (@IdCourse, @Wallet, @Royalts, @Active)", coProducer, transaction: transaction);
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
    }
}
