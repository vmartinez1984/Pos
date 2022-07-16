using Pos.Core.Entities;

namespace Pos.Core.Interfaces.IRepositories
{
    public interface IRepository
    {
        public IUserRepository User { get; }

        public IRoleRepository Role { get; }

        public IProductRepository Product { get; }

        public ISaleRepository Sale { get; }

        public IStoreRepository Store { get; }
        
    }

    public interface ISaleRepository
    {
        Task<string> AddAsync(string userId);
        
        Task AddProductAsync(ProductSaleEntity product, string saleId);

        Task<SaleEntity> GetAsync(string saleId);

        Task UpdateAsync(SaleEntity saleEntity);
    }

    public interface IStoreRepository
    {
        Task<string> AddAsync(StoreEntity entity);

        Task<StoreEntity> GetAsync(string barcode);

        Task SubstractPieces(string barcode, int piezas);
        
        Task<List<StoreEntity>> GetAsync();
        Task UpdateAsync(StoreEntity storeEntity);
    }

    public interface IRoleRepository
    {
        Task<List<RoleEntity>> GetAsync();

        Task<string> GetNameAsync(string roleId);
    }

    public interface IUserRepository
    {
        Task<string> AddAsync(UserEntity entity);
        Task<List<UserEntity>> GetAsync();
        Task<UserEntity> GetAsync(string email);
        Task<bool> ExistsEmailAsync(string email);
    }

    public interface IProductRepository
    {
        Task<string> AddAsync(ProductEntity entity);

        Task<List<ProductEntity>> GetAsync();

        Task<ProductEntity> GetAsync(string productId);

        Task<bool> ExistsCodeBarAsync(string codeBar);
    }
}