using AutoMapper;
using Pos.Core.Dtos;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IBusinesLayer;
using Pos.Core.Interfaces.IRepositories;

namespace Pos.BusinessLayer
{
    public class ProductBl : IProductBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public ProductBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(ProductDtoIn item)
        {
            ProductEntity entity;

            entity = _mapper.Map<ProductEntity>(item);
            entity.Id = await _repository.Product.AddAsync(entity);

            return entity.Id;
        }

        public Task<bool> ExistsBarcodeAsync(string barcode)
        {
            return _repository.Product.ExistsCodeBarAsync(barcode);
        }

        public async Task<List<ProductDto>> GetAsync()
        {
            List<ProductDto> list;
            List<ProductEntity> entities;

            entities = await _repository.Product.GetAsync();
            list = _mapper.Map<List<ProductDto>>(entities);

            return list;
        }

        public async Task<ProductDto> GetAsync(string productId)
        {
            ProductDto item;
            ProductEntity entity;

            entity = await _repository.Product.GetAsync(productId);
            item = _mapper.Map<ProductDto>(entity);

            return item;
        }
    }
}