using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infrastructure.DrivenAdapter.Gateway;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<Director> GetDirectorByIdAsync(int idDirector)
        {
            throw new NotImplementedException();
        }

        public Task<Director> InsertDirectorAsync(Director director)
        {
            throw new NotImplementedException();
        }

        public Task<Director> InsertDirectorSqlKataAsync(Director director)
        {
            throw new NotImplementedException();
        }
    }
}
