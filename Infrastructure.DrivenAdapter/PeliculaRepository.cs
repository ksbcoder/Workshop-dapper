using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infrastructure.DrivenAdapter.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DrivenAdapter
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;

        public PeliculaRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<List<Pelicula>> GetMoviesAsync()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = "SELECT * FROM peliculas";
            var resultado = await connection.QueryAsync<Pelicula>(sqlQuery);
            return resultado.ToList();
        }

        public Task<Pelicula> InsertMovieAsync(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
