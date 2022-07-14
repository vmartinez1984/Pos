using Pos.Core.Interfaces.IRepositories;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class RepositoryMongoDb : IRepository
    {

        public RepositoryMongoDb(
            IProductRepository productRepository
            , IUserRepository userRepository
            , IRoleRepository roleRepository
            , ISaleRepository saleRepository
            , IStoreRepository storeRepository
        )
        {
            this.Product = productRepository;
            this.User = userRepository;
            this.Role = roleRepository;
            this.Sale = saleRepository;
            this.Store = storeRepository;
        }

        public IUserRepository User { get; }

        public IRoleRepository Role { get; }

        public IProductRepository Product { get; }

        public ISaleRepository Sale { get; }

        public IStoreRepository Store { get; }
    }
}