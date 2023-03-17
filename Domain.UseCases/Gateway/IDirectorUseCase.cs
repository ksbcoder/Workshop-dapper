using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Gateway
{
    public interface IDirectorUseCase
    {
        Task<Director> AgregarDirector(Director director);

        Task<List<Director>> ObtenerListaDirectores();

        Task<Director> ObtenerDirectorPorId(int id);



    }
}
