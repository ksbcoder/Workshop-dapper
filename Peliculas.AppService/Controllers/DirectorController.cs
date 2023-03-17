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
    public class DirectorController : ControllerBase
    {

        private readonly IDirectorUseCase _directorUseCase;
        private readonly IMapper _mapper;


        public DirectorController(IDirectorUseCase directorUseCase, IMapper mapper)
        {
            _directorUseCase = directorUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Director>> Obtener_Listado_Directores()
        {
            return await _directorUseCase.ObtenerListaDirectores();
        }

        [HttpGet("directorporid")]
        public async Task<Director> Obtener__Director_Por_Id([FromQuery] int idDirector)
        {
            return await _directorUseCase.ObtenerDirectorPorId(idDirector);
        }

        [HttpPost]
        public async Task<Director> Insertar_Director([FromBody] InsertNewDirector command)
        {
            return await _directorUseCase.AgregarDirector(_mapper.Map<Director>(command));
        }
    }
}
