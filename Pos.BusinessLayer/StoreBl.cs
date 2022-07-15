using AutoMapper;
using Pos.Core.Dtos;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IBusinesLayer;
using Pos.Core.Interfaces.IRepositories;

namespace Pos.BusinessLayer
{
    public class StoreBl : IStoreBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public StoreBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(StoreDtoIn item)
        {
            StoreEntity entity;

            entity = _mapper.Map<StoreEntity>(item);
            entity.Id = await _repository.Store.AddAsync(entity);

            return entity.Id;
        }

        public async Task<List<StoreDto>> GetAsync()
        {
            List<StoreDto> list;
            List<StoreEntity> entities;

            entities = await _repository.Store.GetAsync();
            list = _mapper.Map<List<StoreDto>>(entities);

            return list;
        }

        public async Task<StoreDto> GetAsync(string id)
        {
            StoreEntity entity;
            StoreDto item;

            entity = await _repository.Store.GetAsync(id);
            item = _mapper.Map<StoreDto>(entity);

            return item;
        }
    }
}