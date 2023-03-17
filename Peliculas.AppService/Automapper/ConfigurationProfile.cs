using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;

namespace Peliculas.AppService.Automapper
{
    public class ConfigurationProfile : Profile
    {

        public ConfigurationProfile()
        {
            CreateMap<InsertNewDirector, Director>().ReverseMap();
            CreateMap<InsertNewMovie, Pelicula>().ReverseMap();
        }
    }
}
