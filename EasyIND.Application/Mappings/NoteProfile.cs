using AutoMapper;
using EasyIND.Application.Dtos;
using EasyIND.Application.Extensions;
using EasyIND.Domain.Entities;

namespace EasyIND.Application.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            this._CreateMap_WithConventions_FromAssemblies<User, UserDto>();
        }
    }
}
