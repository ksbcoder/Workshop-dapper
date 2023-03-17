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

        public async Task<Director> AgregarDirector(Director director)
        {
            return await _directorRepository.InsertDirectorAsync(director);
        }

        public async Task<Director> ObtenerDirectorPorId(int id)
        {
            return await _directorRepository.GetDirectorByIdAsync(id);
        }

        public async Task<List<Director>> ObtenerListaDirectores()
        {
            return await _directorRepository.GetAllDirectorsAsync();
        }
    }
}
