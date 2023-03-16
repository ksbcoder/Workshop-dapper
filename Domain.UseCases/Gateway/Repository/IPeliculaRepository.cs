using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Gateway.Repository
{
    public interface IPeliculaRepository
    {
        Task<Pelicula> InsertMovieAsync(Pelicula pelicula);

        Task<List<Pelicula>> GetMoviesAsync();
    }
}
