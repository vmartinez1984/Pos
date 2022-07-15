using AutoMapper;
using Pos.Core.Dtos;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IBusinesLayer;
using Pos.Core.Interfaces.IRepositories;

namespace Pos.BusinessLayer
{
    public class SaleBl : ISaleBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public SaleBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SaleDto> AddProduct(ProductSaleDtoIn product)
        {
            //Verificamos que este en existencia en almacen
            StoreEntity storeEntity;
            ProductSaleEntity productSaleEntity;            
            SaleDto saleDto;

            storeEntity = await _repository.Store.GetAsync(product.Barcode);
            if (storeEntity.Pieces == 0)
            {
                throw new Exception("No hay existencias en almacen");
            }
            productSaleEntity = await GetProductSaleEntityAsync(product.Barcode);
            await _repository.Sale.AddProductAsync(productSaleEntity, product.SaleId);
            await _repository.Store.SubstractPieces(product.Barcode, 1);
            saleDto = await GetAsync(product.SaleId);

            return saleDto;
        }

        private async Task<ProductSaleEntity> GetProductSaleEntityAsync(string barcode)
        {
            ProductSaleEntity productSaleEntity;
            ProductEntity productEntity;

            productEntity = await _repository.Product.GetAsync(barcode);
            productSaleEntity = new ProductSaleEntity
            {
                Barcode = barcode,
                Name = productEntity.Name,
                Price = productEntity.Price
            };

            return productSaleEntity;
        }

        public async Task<string> StartAsync(SaleDtoIn item)
        {
            string id;

            id = await _repository.Sale.AddAsync(item.UserId);

            return id;
        }

        public async Task<SaleDto> GetAsync(string id)
        {
            SaleEntity saleEntity;
            SaleDto saleDto;

            saleEntity = await _repository.Sale.GetAsync(id);
            saleDto = _mapper.Map<SaleDto>(saleEntity);

            return saleDto;
        }
    }
}