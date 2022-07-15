using AutoMapper;
using Pos.Core.Dtos;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IBusinesLayer;
using Pos.Core.Interfaces.IRepositories;

namespace Pos.BusinessLayer
{
    public class UserBl : IUserBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public UserBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAsync()
        {
            List<UserDto> list;
            List<UserEntity> entities;

            entities = await _repository.User.GetAsync();
            list = _mapper.Map<List<UserDto>>(entities);

            return list;
        }

        public async Task<string> AddAsync(UserDtoIn user)
        {
            UserEntity entity;

            entity = _mapper.Map<UserEntity>(user);
            entity.Id = await _repository.User.AddAsync(entity);

            return entity.Id;
        }

        public async Task<UserDto> LoginAsync(UserLoginDtoIn userLogin)
        {
            UserEntity entity;
            UserDto user;

            user = null;
            entity = await _repository.User.GetAsync(userLogin.Email);
            if (entity is not null)
            {
                if (entity.Password == userLogin.Password)
                {
                    entity.Password = string.Empty;
                    user = _mapper.Map<UserDto>(entity);
                }
            }

            return user;
        }

        public async Task<bool> ExistsEmailAsync(string email)
        {
            return await _repository.User.ExistsEmailAsync(email);
        }
    }
}