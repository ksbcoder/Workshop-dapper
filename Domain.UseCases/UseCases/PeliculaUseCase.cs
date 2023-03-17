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
    public class PeliculaUseCase : IPeliculaUseCase
    {
        private readonly IPeliculaRepository _peliculaRepository;

        public PeliculaUseCase(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        public Task<Pelicula> AgregarPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pelicula>> ObtenerListadoPeliculas()
        {
            return await _peliculaRepository.GetMoviesAsync();
        }
    }
}
