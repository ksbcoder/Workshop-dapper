using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infrastructure.DrivenAdapter.Gateway;
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

        public DirectorRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public Task<List<Director>> GetAllDirectorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Director> InsertDirectorAsync(Director director)
        {
            throw new NotImplementedException();
        }
    }
}
