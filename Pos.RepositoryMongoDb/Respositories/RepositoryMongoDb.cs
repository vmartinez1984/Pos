using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pos.Core.Interfaces.IRepositories;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class RepositoryMongoDb : IRepository
    {

        public RepositoryMongoDb(
            IProductRepository productRepository
            , IUserRepository userRepository
            , IRoleRepository roleRepository
        )
        {
            this.Product = productRepository;
            this.User = userRepository;
            this.Role = roleRepository;
        }        

        public IUserRepository User { get; }

        public IRoleRepository Role { get; }

        public IProductRepository Product { get; }
    }
}