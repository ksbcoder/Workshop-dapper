using Domain.Entities.Entities;
using Domain.UseCases.Gateway;
using Domain.UseCases.Gateway.Repository;

namespace Domain.UseCases.UseCases
{
    public class PeliculaUseCase : IPeliculaUseCase
    {
        private readonly IPeliculaRepository _peliculaRepository;

        public PeliculaUseCase(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        public async Task<Pelicula> AgregarPelicula(Pelicula pelicula)
        {
            return await _peliculaRepository.InsertMovieAsync(pelicula);
        }

        public async Task<Pelicula> AgregarPeliculaSqlKata(Pelicula pelicula)
        {
            return await _peliculaRepository.InsertMovieSqlKataAsync(pelicula);
        }

        public async Task<List<Pelicula>> ObtenerListadoPeliculas()
        {
            return await _peliculaRepository.GetMoviesAsync();
        }

        public async Task<Pelicula> ObtenerPeliculaByIdSqlKata(int id)
        {
            return await _peliculaRepository.GetMovieByIdSqlKataAsync(id);
        }

        public async Task<IEnumerable<PeliculaConDirector>> ObternerPeliculaConDirectorById(int id)
        {
            return await _peliculaRepository.GetMovieWithDirectorById(id);
        }

        public async Task<PeliculaConDirector> ObternerPeliculaConDirectorByIdSqlKata(int id)
        {
            return await _peliculaRepository.GetMovieWithDirectorByIdSqlKataAsync(id);
        }
    }
}
