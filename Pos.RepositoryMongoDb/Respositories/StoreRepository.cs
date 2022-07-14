using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pos.Core.Entities;
using Pos.Core.Interfaces.IRepositories;
using Pos.RepositoryMongoDb.DataBaseSettings;

namespace Pos.RepositoryMongoDb.Respositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IMongoCollection<StoreEntity> _collection;

        public StoreRepository(IOptions<PosDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<StoreEntity>(
                databaseSettings.Value.StoreCollectionName);
        }

        public async Task<string> AddAsync(StoreEntity entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity.Id;
        }

        public Task<StoreEntity> GetAsync(string barcode)
        {
            throw new NotImplementedException();
        }

        public Task<List<StoreEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task SubstractPieces(string barcode, int piezas)
        {
            throw new NotImplementedException();
        }
    }
}