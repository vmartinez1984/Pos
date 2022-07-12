using AutoMapper;
using Pos.Core.Dtos;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IBusinesLayer;
using Pos.Core.Interfaces.IRepositories;

namespace Pos.BusinessLayer
{
    public class RoleBl: IRoleBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public RoleBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> GetAsync()
        {
            List<RoleDto> list;
            List<RoleEntity> entities;

            entities = await _repository.Role.GetAsync();
            list = _mapper.Map<List<RoleDto>>(entities);

            return list;
        }
    }
}