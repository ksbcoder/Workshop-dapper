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

        [HttpGet("id")]
        public async Task<Director> Obtener_Director_Por_Id(int directorID)
        {
            return await _directorUseCase.ObtenerDirectorPorId(directorID);
        }

        [HttpPost]
        public async Task<Director> Agregar_Director(InsertNewDirector directorCommand)
        {
            return await _directorUseCase.AgregarDirector(_mapper.Map<Director>(directorCommand));
        }

        [HttpPost("SqlKata")]
        public async Task<Director> Agregar_Director_Con_Kata(InsertNewDirector directorCommand)
        {
            return await _directorUseCase.InsertarDirectorConKata(_mapper.Map<Director>(directorCommand));
        }
    }
}
