using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IRepositories;
using Pos.RepositoryMongoDb.DataBaseSettings;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IMongoCollection<SaleEntity> _collection;

        public SaleRepository(IOptions<PosDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<SaleEntity>(
                databaseSettings.Value.SalesCollectionName);
        }

        public async Task<string> AddAsync(string userId)
        {
            SaleEntity entity;

            entity = new SaleEntity
            {
                UserId = userId,
                DateRegistration = DateTime.Now,
                IsActive = true,
                Total = 0,
                ListProducts = new List<ProductSaleEntity>(),
                State = "Inicio"
            };
            await _collection.InsertOneAsync(entity);

            return entity.Id;
        }

        public async Task AddProductAsync(ProductSaleEntity product, string saleId)
        {
            SaleEntity entity;

            entity = await _collection.Find(x => x.Id == saleId).FirstOrDefaultAsync();
            entity.ListProducts.Add(product);
            entity.Total = entity.ListProducts.Sum(x => x.Price);
            
            await _collection.ReplaceOneAsync(x => x.Id == saleId, entity);
        }

        public async Task<SaleEntity> GetAsync(string saleId)
        {
             SaleEntity entity;

            entity = await _collection.Find(x => x.Id == saleId).FirstOrDefaultAsync();

            return entity;
        }
    }
}