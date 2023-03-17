using AutoMapper;
using Domain.Entities.Commands;
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
        private readonly IMapper _mapper;

        public PeliculaController(IPeliculaUseCase peliculaUseCase, IMapper mapper)
        {
            _peliculaUseCase = peliculaUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Pelicula>> Obtener_Peliculas()
        {
            return await _peliculaUseCase.ObtenerListadoPeliculas();
        }

    }
}
