using AutoMapper;
using Pos.Core.Dtos;
using Pos.Core.Entities;

namespace Pos.Core.Mappers
{
    public class MapperImplements : Profile
    {
        public MapperImplements()
        {
            CreateMap<UserDtoIn, UserEntity>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<RoleEntity, RoleDto>();

            CreateMap<ProductDtoIn, ProductEntity>();
            CreateMap<ProductEntity, ProductDto>();
        }
    }
}