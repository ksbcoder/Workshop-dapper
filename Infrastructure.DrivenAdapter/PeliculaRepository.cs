using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infrastructure.DrivenAdapter.Gateway;
using System.IO;

namespace Infrastructure.DrivenAdapter
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "peliculas";

        public PeliculaRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<List<Pelicula>> GetMoviesAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var resultado = await connection.QueryAsync<Pelicula>(sqlQuery);
            connection.Close();
            return resultado.ToList();
        }

        public async Task<Pelicula> InsertMovieAsync(Pelicula pelicula)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var ff = new { nombre = pelicula.Nombre_Pelicula,
                lanzamiento = pelicula.Lanzamiento,
                cantidad = pelicula.Cantidad_Disponible,
                idDirector = pelicula.Id_Director  
            };
            string sqlQuery = $"INSERT INTO {tableName} (nombre_pelicula, lanzamiento, cantidad_disponible, id_director)VALUES(@nombre, @lanzamiento, @cantidad, @idDirector)";
            var rows = await connection.ExecuteAsync(sqlQuery, ff);
            return pelicula;
        }
    }
}
