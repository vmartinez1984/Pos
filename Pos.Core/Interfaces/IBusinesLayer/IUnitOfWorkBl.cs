using Pos.Core.Dtos;

namespace Pos.Core.Interfaces.IBusinesLayer
{
    public interface IUnitOfWorkBl
    {
        public IUserBl User { get; }
        public IRoleBl Role { get; }
        public IProductBl Product { get; }
        public ISaleBl Sale { get; }
        public IStoreBl Store { get; }
    }

    public interface IStoreBl
    {
        Task<string> AddAsync(StoreDtoIn item);

        Task<StoreDto> GetAsync(string id);
    }

    public interface ISaleBl
    {
        Task<string> StartAsync(SaleDtoIn item);
        Task<SaleDto> AddProduct(ProductSaleDtoIn product);
        Task<SaleDto> GetAsync(string id);
    }

    public interface IProductBl
    {
        Task<List<ProductDto>> GetAsync();

        Task<string> AddAsync(ProductDtoIn item);
        Task<ProductDto> GetAsync(string productId);
        Task<bool> ExistsBarcodeAsync(string barcode);
    }

    public interface IRoleBl
    {
        Task<List<RoleDto>> GetAsync();
    }

    public interface IUserBl
    {
        Task<List<UserDto>> GetAsync();

        Task<string> AddAsync(UserDtoIn user);

        Task<UserDto> LoginAsync(UserLoginDtoIn userLogin);
        
        Task<bool> ExistsEmailAsync(string email);
    }
}