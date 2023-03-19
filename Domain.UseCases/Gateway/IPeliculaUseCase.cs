using Domain.Entities.Entities;

namespace Domain.UseCases.Gateway
{
    public interface IPeliculaUseCase
    {
        Task<List<Pelicula>> ObtenerListadoPeliculas();

        Task<Pelicula> ObtenerPeliculaByIdSqlKata(int id);

        Task<IEnumerable<PeliculaConDirector>> ObternerPeliculaConDirectorById(int id);

        Task<PeliculaConDirector> ObternerPeliculaConDirectorByIdSqlKata(int id);

        Task<Pelicula> AgregarPelicula(Pelicula pelicula);

        Task<Pelicula> AgregarPeliculaSqlKata(Pelicula pelicula);
    }
}
