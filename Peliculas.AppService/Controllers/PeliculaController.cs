using Domain.Entities.Entities;
using Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Peliculas.AppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaUseCase _peliculaUseCase;

        public PeliculaController(IPeliculaUseCase peliculaUseCase)
        {
            _peliculaUseCase = peliculaUseCase;
        }

        [HttpGet]
        public async Task<List<Pelicula>> Obtener_Peliculas()
        {
            return await _peliculaUseCase.ObtenerListadoPeliculas();
        }
    }
}
