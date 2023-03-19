using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infrastructure.DrivenAdapter.Gateway;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

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

        public async Task<Pelicula> GetMovieByIdSqlKataAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var factoryKata = new QueryFactory(connection, new SqlServerCompiler());

            var result = await factoryKata.Query(tableName).Where("id", id).FirstOrDefaultAsync<Pelicula>();
            connection.Close();
            return result;
        }

        public async Task<List<Pelicula>> GetMoviesAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var resultado = await connection.QueryAsync<Pelicula>(sqlQuery);
            connection.Close();
            return resultado.ToList();
        }

        public async Task<IEnumerable<PeliculaConDirector>> GetMovieWithDirectorById(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            string sqlQuery = $"SELECT * FROM {tableName} p  INNER JOIN directores d ON d.id = p.id_director  WHERE p.id = @id";

            var peliculaConDirector = await connection.QueryAsync<PeliculaConDirector, Director, PeliculaConDirector>(sqlQuery, (pelicula, director) =>
            {
                pelicula.Director = director;
                return pelicula;
            },
            new { id },
            splitOn: "id_director");

            connection.Close();
            return peliculaConDirector;
        }

        //No funciona correctamente
        public async Task<PeliculaConDirector> GetMovieWithDirectorByIdSqlKataAsync(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var factoryKata = new QueryFactory(connection, new SqlServerCompiler());

            var peliculaConDirector = await factoryKata.Query(tableName)
                .Join("directores", "directores.id", $"{tableName}.id_director")
                .Where($"{tableName}.id", id)
                .Select($"{tableName}.*", "directores.*")
                .FirstOrDefaultAsync<PeliculaConDirector>();

            connection.Close();
            return peliculaConDirector;
        }

        public async Task<Pelicula> InsertMovieAsync(Pelicula pelicula)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var peliculaAgregar = new
            {
                nombre = pelicula.Nombre_Pelicula,
                lanzamiento = pelicula.Lanzamiento,
                cantidad = pelicula.Cantidad_Disponible,
                idDirector = pelicula.Id_Director
            };
            string sqlQuery = $"INSERT INTO {tableName} (nombre_pelicula, lanzamiento, cantidad_disponible, id_director)VALUES(@nombre, @lanzamiento, @cantidad, @idDirector)";
            var rows = await connection.ExecuteAsync(sqlQuery, peliculaAgregar);
            return pelicula;
        }

        public async Task<Pelicula> InsertMovieSqlKataAsync(Pelicula pelicula)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var factoryKata = new QueryFactory(connection, new SqlServerCompiler());

            var peliculaAgregar = new
            {
                nombre_pelicula = pelicula.Nombre_Pelicula,
                lanzamiento = pelicula.Lanzamiento,
                cantidad_disponible = pelicula.Cantidad_Disponible,
                id_director = pelicula.Id_Director
            };

            var result = await factoryKata.Query(tableName).InsertAsync(peliculaAgregar);
            connection.Close();
            return pelicula;
        }
    }
}
