using Domain.Entities.Entities;

namespace Domain.UseCases.Gateway.Repository
{
    public interface IPeliculaRepository
    {
        Task<Pelicula> InsertMovieAsync(Pelicula pelicula);

        Task<Pelicula> InsertMovieSqlKataAsync(Pelicula pelicula);

        Task<List<Pelicula>> GetMoviesAsync();

        Task<Pelicula> GetMovieByIdSqlKataAsync(int id);

        Task<IEnumerable<PeliculaConDirector>> GetMovieWithDirectorById(int id);

        Task<PeliculaConDirector> GetMovieWithDirectorByIdSqlKataAsync(int id);
    }
}
