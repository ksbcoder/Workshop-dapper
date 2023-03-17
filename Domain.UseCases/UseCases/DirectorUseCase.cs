using Domain.Entities.Entities;
using Domain.UseCases.Gateway;
using Domain.UseCases.Gateway.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.UseCases
{
    public class DirectorUseCase : IDirectorUseCase
    {

        private readonly IDirectorRepository _directorRepository;

        public DirectorUseCase(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public Task<Director> AgregarDirector(Director director)
        {
            throw new NotImplementedException();
        }

        public Task<Director> InsertarDirectorConKata(Director director)
        {
            throw new NotImplementedException();
        }

        public Task<Director> ObtenerDirectorPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Director>> ObtenerListaDirectores()
        {
            return await _directorRepository.GetAllDirectorsAsync();
        }
    }
}
