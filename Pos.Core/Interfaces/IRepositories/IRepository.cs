using Pos.Core.Entities;

namespace Pos.Core.Interfaces.IRepositories
{
    public interface IRepository
    {
        //public IProductRepository Product { get; }
        public IUserRepository User { get; }

        public IRoleRepository Role { get; }
        public IProductRepository Product { get; }
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
    }

    public interface IProductRepository
    {
        Task<string> AddAsync(ProductEntity entity);

        Task<List<ProductEntity>> GetAsync();

        Task<ProductEntity> GetAsync(string productId);

        Task<bool> ExistsCodeBarAsync(string codeBar);
    }
}