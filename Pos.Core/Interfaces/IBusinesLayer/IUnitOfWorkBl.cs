using Pos.Core.Dtos;

namespace Pos.Core.Interfaces.IBusinesLayer
{
    public interface IUnitOfWorkBl
    {
        public IUserBl User { get; }
        public IRoleBl Role { get; }
        public IProductBl Product { get; }
    }

    public interface IProductBl
    {
        Task<List<ProductDto>> GetAsync();

        Task<string> AddAsync(ProductDtoIn item);
        Task<ProductDto> GetAsync(string productId);
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
    }
}