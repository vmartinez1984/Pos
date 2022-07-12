using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IRepositories;
using Pos.RepositoryMongoDb.DataBaseSettings;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<ProductEntity> _collection;

        public ProductRepository(IOptions<PosDatabaseSettings> productSettings)
        {
            var mongoClient = new MongoClient(productSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(productSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<ProductEntity>(productSettings.Value.ProductsCollectionName);
        }

        public async Task<string> AddAsync(ProductEntity entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity.Id;
        }

        public async Task<List<ProductEntity>> GetAsync()
        {
            List<ProductEntity> entities;

            entities = await _collection.Find(_ => true).ToListAsync();

            return entities;
        }

        public async Task<ProductEntity> GetAsync(string codeBar)
        {
            ProductEntity entity;

            entity = await _collection.Find(x => x.CodeBar == codeBar).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<bool> ExistsCodeBarAsync(string codeBar)
        {
            long count;

            count = await _collection.CountAsync(x => x.Id == codeBar);

            return count == 0 ? false : true;
        }

    }//End class
}