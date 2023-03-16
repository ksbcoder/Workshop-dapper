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

        public DirectorController(IDirectorUseCase directorUseCase)
        {
            _directorUseCase = directorUseCase;
        }

        [HttpGet]
        public async Task<List<Director>> Obtener_Listado_Directores()
        {
            return await _directorUseCase.ObtenerListaDirectores();
        }
    }
}
