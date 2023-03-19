using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Gateway.Repository
{
    public interface IDirectorRepository
    {
        Task<Director> InsertDirectorAsync(Director director);

        Task<List<Director>> GetAllDirectorsAsync();

        Task<Director> GetDirectorByIdAsync(int directorID);

        Task<Director> InsertDirectorSqlKataAsync(Director director);
    }
}
