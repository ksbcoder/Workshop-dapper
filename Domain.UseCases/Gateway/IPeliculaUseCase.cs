using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Gateway
{
    public interface IPeliculaUseCase
    {
        Task<List<Pelicula>> ObtenerListadoPeliculas();
    }
}
