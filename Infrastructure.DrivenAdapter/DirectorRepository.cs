using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infrastructure.DrivenAdapter.Gateway;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Infrastructure.DrivenAdapter
{
    public class DirectorRepository : IDirectorRepository
    {

        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "directores";

        public DirectorRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<List<Director>> GetAllDirectorsAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var result = await connection.QueryAsync<Director>(sqlQuery);
            connection.Close();
            return result.ToList();
        }

        public async Task<Director> GetDirectorByIdAsync(int directorID)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName} WHERE id = @directorID";
            var result = await connection.QuerySingleAsync<Director>(sqlQuery, new { directorID });
            connection.Close();
            return result;
        }

        public async Task<Director> InsertDirectorAsync(Director director)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var directorAgregar = new
            {
                nombre = director.Nombre,
                fecha_nacimiento = director.Fecha_Nacimiento,
                cantidad_premios = director.Cantidad_Premios
            };

            string sqlQuery = $"INSERT INTO {tableName} (nombre, fecha_nacimiento, cantidad_premios) VALUES (@nombre, @fecha_Nacimiento, @cantidad_Premios)";
            var result = await connection.ExecuteAsync(sqlQuery, directorAgregar);
            connection.Close();
            return director;
        }

        public async Task<Director> InsertDirectorSqlKataAsync(Director director)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var factoryKata = new QueryFactory(connection, new SqlServerCompiler());

            var directorAgregar = new
            {
                nombre = director.Nombre,
                fecha_nacimiento = director.Fecha_Nacimiento,
                cantidad_premios = director.Cantidad_Premios
            };

            var result = await factoryKata.Query(tableName).InsertAsync(directorAgregar);
            connection.Close();
            return director;
        }
    }
}
