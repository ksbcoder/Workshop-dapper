using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway;
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

        [HttpGet("SqlKata/{id}")]
        public async Task<Pelicula> Obtener_Pelicula(int id)
        {
            return await _peliculaUseCase.ObtenerPeliculaByIdSqlKata(id);
        }

        [HttpGet("ConDirector/{id}")]
        public async Task<IEnumerable<PeliculaConDirector>> Obtener_Pelicula_Con_Director(int id)
        {
            return await _peliculaUseCase.ObternerPeliculaConDirectorById(id);
        }

        [HttpGet("SqlKata/ConDirector/{id}")]
        public async Task<PeliculaConDirector> Obtener_Pelicula_Con_Director_SqlKata(int id)
        {
            return await _peliculaUseCase.ObternerPeliculaConDirectorByIdSqlKata(id);
        }

        [HttpPost]
        public async Task<Pelicula> Agregar_Pelicula(InsertNewMovie peliculaCommand)
        {
            return await _peliculaUseCase.AgregarPelicula(_mapper.Map<Pelicula>(peliculaCommand));
        }

        [HttpPost("SqlKata")]
        public async Task<Pelicula> Agregar_Pelicula_SqlKata(InsertNewMovie peliculaCommand)
        {
            return await _peliculaUseCase.AgregarPeliculaSqlKata(_mapper.Map<Pelicula>(peliculaCommand));
        }

    }
}
